using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Services;

public interface IAuthService
{
    // Task<User?> Login(string UserName, string Password);
    Task<LoginResponseDTO?> Login(string UserName,string Password);
}