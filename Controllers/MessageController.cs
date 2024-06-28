using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using chatapi.Data;
using chatapi.Models;

namespace chatapi.Controllers;

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
        return await _context.Messages.ToListAsync();
        
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
        return Ok(await _context.Messages.FindAsync(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMessage(int id, Message message)
    {
        _context.Entry(message).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
        var message = await _context.Messages.FindAsync(id);
        _context.Messages.Remove(message);
        await _context.SaveChangesAsync();
        return Ok(message);
    }
}

