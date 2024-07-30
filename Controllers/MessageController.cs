using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chatapi.Data;
using chatapi.Models;
using Microsoft.AspNetCore.Authorization;

namespace chatapi.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MessageController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Message>> GetMessages()
    {
        Console.WriteLine("GetMessages called");
        var result = await _context.Messages.ToListAsync();
        return result;

    }
    [HttpPost]
    public async Task<IActionResult> CreateMessage(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
        return Ok(message);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMessage(int id)
    {
        var message = await _context.Messages.Include(m => m.FromUser).Include(m => m.ToUser).FirstOrDefaultAsync(m => m.Id == id);
        var result = new
        {
            messageId = message.Id,
            content = message.Content,
            from = message.FromUser.Firstname,
            to = message.ToUser.Firstname,
        };
        if (message == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMessage(int id, Message message)
    {
        _context.Entry(message).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(message);
    }

}

