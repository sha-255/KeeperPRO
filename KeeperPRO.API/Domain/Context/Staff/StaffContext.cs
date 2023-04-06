using KeeperPRO.Api.Common.Exeptions;
using Microsoft.EntityFrameworkCore;

namespace KeeperPRO.Api.Domain.Context.Staff
{
    public class StaffContext : DbContext
    {
        public StaffContext(DbContextOptions<StaffContext> options)
            : base(options)
        {
            if (options == null)
                throw new NotFoundExeption<StaffContext>();
        }

        public DbSet<KeeperPRO.Domain.Data.Staff> Staffs { get; set; }
    }
}