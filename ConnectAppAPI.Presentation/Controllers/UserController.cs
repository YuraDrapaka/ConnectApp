using ConnectAppAPI.DataAccess;
using ConnectAppAPI.DataAccess.Repositories;
using ConnectAppAPI.Presentation.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConnectAppAPI.Presentation.Controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;
        public UserController( IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {            
            var users = await _userRepo.GetAllAsync();
            return Ok(users.Select(s => s.ToUserDTO()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var user = await _userRepo.GetByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDTO());
        }
    }
}
