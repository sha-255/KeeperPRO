using KeeperPRO.Api.Domain.Context.User;
using KeeperPRO.Api.Domain.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeeperPRO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupVisitController : Controller
    {
        private readonly UserGroupVisitContext _context;

        public UserGroupVisitController(UserGroupVisitContext context)
            => _context = context;

        [HttpGet]
        public async Task<IEnumerable<UserGroupVisit>> Get()
            => await _context.UsersGroupVisit.ToListAsync();

        [HttpGet("login")]
        public async Task<IActionResult> GetByLogin(string login)
        {
            var user = await _context.UsersGroupVisit.FindAsync(login);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserGroupVisit user)
        {
            await _context.UsersGroupVisit.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut("login")]
        public async Task<IActionResult> Update(string login, UserGroupVisit user)
        {
            if (user.Login != login)
                return BadRequest();
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("login")]
        public async Task<IActionResult> Delete(string login)
        {
            var user =  await _context.UsersGroupVisit.FindAsync(login);
            _context.UsersGroupVisit.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}