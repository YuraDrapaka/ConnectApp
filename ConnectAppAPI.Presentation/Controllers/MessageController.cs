using AppDbContextAPI.DataAccess;
using ConnectAppAPI.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConnectAppAPI.Presentation.Controllers
{
    [Route("/message")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly AppDbContext _context;
        public MessageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var messages = _context.Messages.ToList();
            return Ok(messages);
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var message = _context.Messages.Find(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }
    }
}
