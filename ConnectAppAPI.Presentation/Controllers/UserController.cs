using ConnectAppAPI.DataAccess;
using ConnectAppAPI.Presentation.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace ConnectAppAPI.Presentation.Controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.AspNetUsers.ToList().Select(s => s.ToUserDTO());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.AspNetUsers.Find(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDTO());
        }
    }
}
