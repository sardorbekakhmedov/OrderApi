namespace OrderApi.Services;

public class FileServices
{
    private const string RootFolderPath = "wwwroot";

    private string CheckHasFolder(string folderName)
    {
        var rootPath = Path.Combine(Environment.CurrentDirectory, RootFolderPath);

        if (!Directory.Exists(rootPath))
            Directory.CreateDirectory(RootFolderPath);

        var folderPath = Path.Combine(rootPath, folderName);

        if(!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        return folderPath;
    }

    public async Task<string> SaveFileAsync(IFormFile formFile, string folderName)
    {
        var folderPath = CheckHasFolder(folderName);

        var fileName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);

        var filePath = Path.Combine(folderPath, fileName);
        await using var stream = new FileStream(filePath, FileMode.Create);
        await formFile.CopyToAsync(stream);

        return filePath;
    }

    public void DeleteFile(string filePath)
    {
        var path = Path.Combine(Environment.CurrentDirectory, filePath);

        if(File.Exists(path))
            File.Delete(path);
    }
}