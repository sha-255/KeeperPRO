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
    }
}