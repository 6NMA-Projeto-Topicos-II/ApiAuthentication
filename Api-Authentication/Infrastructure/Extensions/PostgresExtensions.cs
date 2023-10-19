using Api_Authentication.Adapters.Sql.Connections;
using Api_Authentication.Adapters.Sql.Repository;
using Api_Authentication.Port.OutboundPort;
using Microsoft.EntityFrameworkCore;

namespace Api_Authentication.Infrastructure.Extensions
{
    public static class PostgresExtensions
    {
        public static void AddSqlPostgresExtensions(this IServiceCollection service,IConfiguration configuration)
        {
            var connect = configuration.GetSection("SqlConnect").Get<ConnectionStrings>();
            service.AddDbContext<SQLContext>(options =>
                  options.UseNpgsql(connect.GetConnectString("ClustLocal", "DbCampusHub")));

            service.AddScoped<IRepository, Repository>();

         }
    }
}
