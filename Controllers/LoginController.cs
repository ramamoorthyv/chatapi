using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chatapi.Data;
using chatapi.Models;
using chatapi.Helpers;

namespace chatapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LoginController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Login(Login loginModel)
    {
        var message = "User not found";
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginModel.Email);
        if (user == null || !Password.VerifyPassword(loginModel.Password, user.Password))
        {
            return Unauthorized(message);
        }
        return Ok(new { message = "Login successful", token =  123});

    }
}