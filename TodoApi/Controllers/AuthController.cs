using LoginApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthConroller : ControllerBase
{
    private readonly IAuthService _authservice;
    public AuthConroller(IAuthService authservice)
    {
        _authservice=authservice;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestDTO dto)
    {
        var response = await _authservice.Login(
            dto.UserName,
            dto.Password
        );
        if (response == null)
        {
            return Unauthorized("Invalid UserName or Password.");
        }
        return Ok(response);
    }
}