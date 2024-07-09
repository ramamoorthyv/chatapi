using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chatapi.Data;
using chatapi.Models;
using chatapi.Helpers;

namespace chatapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SignupController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SignupController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Signup(User user)
    {
        user.Password = Password.HashPassword(user.Password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }
    
}
