using KeeperPRO.Api.Domain.Data;
using KeeperPRO.Common.Exeptions;
using Microsoft.EntityFrameworkCore;

namespace KeeperPRO.Api.Domain.Context.User
{
    public class UserPersonalVisitContext : DbContext
    {
        public UserPersonalVisitContext(DbContextOptions<UserPersonalVisitContext> options)
            : base(options)
        {
            if (options == null)
                throw new NotFoundExeption<UserPersonalVisitContext>();
        }

        public DbSet<UserPersonalVisit> UsersPersonalVisit { get; set; }
    }
}