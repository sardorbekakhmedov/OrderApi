namespace OrderApi.Exceptions;

public class LoginValidationException : Exception
{
    public LoginValidationException() : base("Username or password is incorrect") { }
}