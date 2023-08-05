namespace OrderApi.Models;

public record class TokenResultModel(string Token, double Expires, DateTime Date);