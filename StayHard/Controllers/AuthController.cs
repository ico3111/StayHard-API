using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayHard.Application.Domains.Users.Models.Commands;
using StayHard.Application.Domains.Users.Services;

namespace StayHard.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IUserService services) : ControllerBase
{
    private readonly IUserService _services = services;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserCommand command)
    {
        string token = await _services.GetToken(command);

        if (string.IsNullOrEmpty(token))
            return Unauthorized();

        var userData = await _services.GetUserData(command.Email);

        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddHours(2)
        };

        Response.Cookies.Append("stay-hard-auth", token, cookieOptions);

        return Ok(new { id = userData?.Id, name = userData?.Name, email = userData?.Email });
    }

    [Authorize]
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("stay-hard-auth");
        return Ok();
    }

}