using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chatapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    
    [HttpGet("{id}")]
    public IActionResult GetMessage(int id)
    {
        return Ok("Profile " + id);
    }

}

