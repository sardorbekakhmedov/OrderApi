﻿namespace OrderApi.Models.UserModels;

public class LoginUserModel
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}