using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using chatapi.Data;
using chatapi.Models;
using Microsoft.AspNetCore.Authorization;

namespace chatapi.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MessageController : BaseController
{
    private readonly ApplicationDbContext _context;

    public MessageController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> GetMessages([FromQuery] string type)
    {
        var currentUserId = GetCurrentUserId();
        IQueryable<Message> query = _context.Messages;

        if (string.Equals(type, "sent"))
        {
            query = query.Include(m => m.ToUser).Where(i => i.FromUserId == currentUserId);
        }
        else if (string.Equals(type, "received"))
        {
            query = query.Include(m => m.FromUser).Where(i => i.FromUserId == currentUserId);
        }
        else
        {
            return BadRequest("Invalid request");
        }
        var messages = string.Equals(type, "sent") ? await query.Select(p => new { p.Id, p.Content, p.ToUser.Firstname, p.ToUser.Lastname }).ToListAsync() : await query.Select(p => new { p.Id, p.Content, p.FromUser.Firstname, p.FromUser.Lastname }).ToListAsync();
        return Ok(messages);
    }
    [HttpPost]
    public async Task<IActionResult> CreateMessage(Message message)
    {
        message.FromUserId = GetCurrentUserId();
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

