using KeeperPRO.Api.Domain.Data;
using KeeperPRO.Common.Exeptions;
using Microsoft.EntityFrameworkCore;

namespace KeeperPRO.Api.Domain.Context.User
{
    public class UserGroupVisitContext : DbContext
    {
        public UserGroupVisitContext(DbContextOptions<UserGroupVisitContext> options)
            : base(options)
        {
            if (options == null)
                throw new NotFoundExeption<UserGroupVisitContext>();
        }

        public DbSet<UserGroupVisit> UsersGroupVisit { get; set; }
    }
}