using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chatapi.Data;
using chatapi.Models;

namespace chatapi.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
}