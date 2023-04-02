using KeeperPRO.Api.Domain.Context.User;
using KeeperPRO.Api.Domain.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeeperPRO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPersonalVisitController : Controller
    {
        private readonly UserPersonalVisitContext _context;

        public UserPersonalVisitController(UserPersonalVisitContext context)
            => _context = context;

        [HttpGet]
        public async Task<IEnumerable<UserPersonalVisit>> Get()
            => await _context.UsersPersonalVisit.ToListAsync();
    }
}
