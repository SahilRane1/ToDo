using TodoApi.DTOs;
using TodoApi.Models;
using TodoApi.Repositories;
namespace TodoApi.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtservice;
    public AuthService(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository=userRepository;
        _jwtservice=jwtService;
    }
    public async Task<LoginResponseDTO?> Login(string UserName, string Password)
    {
        var user= await _userRepository.GetByUserName(UserName);
        if (user == null)
        {
            return null;
        }
        if(user.Password != Password)
        {
            return null;
        }

        return _jwtservice.GenerateToken(user);
    }
}