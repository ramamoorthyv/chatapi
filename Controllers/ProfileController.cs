using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chatapi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProfileController : ControllerBase
{
    
    [HttpGet("{id}")]
    public IActionResult GetMessage(int id)
    {
        return Ok("Profile " + id);
    }

}

