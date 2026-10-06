using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    public JwtService(IConfiguration configuration)
    {
        _configuration=configuration;
    }
    public LoginResponseDTO GenerateToken(User user)
    {
        var key = _configuration["Jwt:Key"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));

        var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"]));        

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Role,user.Role)
        };

        var token = new JwtSecurityToken(
            issuer : _configuration["Jwt:Issuer"],
            audience : _configuration["Jwt:Audience"],
            claims : claims,
            expires : expiration,
            signingCredentials : credentials
        );




        var tokenHandler = new JwtSecurityTokenHandler();
        // return tokenHandler.WriteToken(token);
        return new LoginResponseDTO
        {
            Token=tokenHandler.WriteToken(token),
            Expiration=expiration
        };
    }
}