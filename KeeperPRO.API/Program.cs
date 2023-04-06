using KeeperPRO.Api.Common.EnumsAndConstants;
using KeeperPRO.Api.Domain.Context.Staff;
using KeeperPRO.Api.Domain.Context.User;
using KeeperPRO.Api.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace KeeperPRO.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StaffContext>(
                option => option.UseSqlServer(
                    builder
                    .Configuration
                    .GetConnectionString(Constants.SqlConnection)));

            builder.Services.AddDbContext<UserGroupVisitContext>(
                option => option.UseSqlServer(
                    builder
                    .Configuration
                    .GetConnectionString(Constants.SqlConnection)));

            builder.Services.AddDbContext<UserPersonalVisitContext>(
                option => option.UseSqlServer(
                    builder
                    .Configuration
                    .GetConnectionString(Constants.SqlConnection)));

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}