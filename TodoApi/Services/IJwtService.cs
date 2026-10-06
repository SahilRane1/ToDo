using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Services;

public interface IJwtService
{
    LoginResponseDTO GenerateToken(User user);
}