using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace chatapi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProfileController : ControllerBase
{
    private readonly HttpContext _httpContext;
    public ProfileController(IHttpContextAccessor httpContextAccessor){
        _httpContext = httpContextAccessor.HttpContext;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetMessage(int id)
    {
        var username = User.Claims.FirstOrDefault(c => c.Type == "Username")?.Value;
        return Ok("Hello " + username);
    }

}

