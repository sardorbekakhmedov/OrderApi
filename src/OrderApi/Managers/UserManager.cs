using Microsoft.AspNetCore.Identity;
using OrderApi.Entities;
using OrderApi.Entities.PageFilters;
using OrderApi.Exceptions;
using OrderApi.Extensions.EntityExtensions;
using OrderApi.Managers.Interfaces;
using OrderApi.Models;
using OrderApi.Models.UserModels;
using OrderApi.Repositories.Interfaces;
using OrderApi.Services;

namespace OrderApi.Managers;

public class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;
    private readonly FileServices _fileService;
    private readonly ITokenManager<User> _tokenManager;
    private const string FolderName = "UserImages";

    public UserManager(IUserRepository userRepository, FileServices fileService, ITokenManager<User> tokenManager)
    {
        _userRepository = userRepository;
        _fileService = fileService;
        _tokenManager = tokenManager;
    }

    public async Task<UserModel> CreateUserAsync(CreateUserModel model)
    {
        var user = new User
        {
           Username = model.Username,
           PhoneNumber = model.PhoneNumber,
           Email = model.Email,
           CreatedAt = DateTime.UtcNow,
        };

        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, model.Password);

        if (model.Image is not null)
            user.ImageUrl = await _fileService.SaveFileAsync(model.Image, FolderName);

        await _userRepository.AddAsync(user);
        
        return user.ToUserModel();
    }

    public async Task<IEnumerable<UserModel>> GetUsersAsync(UserFilter filter)
    {
        var users = await _userRepository.GetUsersAsync(filter);

        return users.Select(x => x.ToUserModel());
    }

    public async Task<TokenResultModel> LoginAsync(LoginUserModel model)
    {
        var user = await _userRepository.GetByUsernameAsync(model.Username);

        if (user is null)
            throw new ObjectNotFoundException(nameof(user));

        var passwordResult = new PasswordHasher<User>()
            .VerifyHashedPassword(user, user.PasswordHash, model.Password);

        if (passwordResult != PasswordVerificationResult.Success)
            throw new LoginValidationException();

        var (token, expires) = _tokenManager.GenerateToken(user);

        return new TokenResultModel(token, expires, DateTime.UtcNow);
    }

    public async Task<UserModel> GetByIdAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null)
            throw new ObjectNotFoundException(nameof(user));

        return user.ToUserModel();
    }

    public async Task<UserModel> UpdateAsync(Guid userId, UpdateUserModel model)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if(user is null)
            throw new ObjectNotFoundException(nameof(user));

        user.Username = model.Username ?? user.Username;
        user.Email = model.Email ?? user.Email;
        user.PhoneNumber = model.PhoneNumber ?? user.PhoneNumber;

        if (model.Password is not null)
            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, model.Password);

        if (model.Image is not null)
        {
            if(user.ImageUrl is not null)
                _fileService.DeleteFile(user.ImageUrl);

            user.ImageUrl = await _fileService.SaveFileAsync(model.Image, FolderName);
        }
        
        await _userRepository.UpdateAsync(user);

        return user.ToUserModel();
    }

    public async Task DeleteAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null)
            throw new ObjectNotFoundException(nameof(user));

        if (user.ImageUrl is not null)
            _fileService.DeleteFile(user.ImageUrl);
        
        await _userRepository.RemoveAsync(user);
    }
}