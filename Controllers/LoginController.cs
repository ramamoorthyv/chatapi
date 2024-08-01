using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chatapi.Data;
using chatapi.Models;
using chatapi.Helpers;
using chatapi.Helpers.Jwt;

namespace chatapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public LoginController(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    
    public async Task<IActionResult> Login(Login loginModel)
    {
        var message = "User not found";
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginModel.Email);
        if (user == null || !Password.VerifyPassword(loginModel.Password, user.Password))
        {
            return Unauthorized(message);
        }
        var token = new JwtGen(_configuration);
        return Ok(new { message = "Login successful", token =  token.GenerateJwtToken(user.Email, user.Id)});

    }

}