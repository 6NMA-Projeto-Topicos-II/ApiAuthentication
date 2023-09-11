using Api_Authentication.Adapters.Sql.Connections;
using Api_Authentication.Adapters.Sql.Repository;
using Api_Authentication.Port.OutboundPort;
using Microsoft.Extensions.DependencyInjection;

namespace Api_Authentication.Infrastructure.Extensions
{
    public static class SQLExtensions
    {
        public static void AddSqlExtensions(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddSingleton(configuration.GetSection("SqlConnect").Get<ConnectionStrings>());
            service.AddSingleton<SQLContext>();

            service.AddScoped<IRepositoryRegister, RepositoryRegister>();

            service.AddScoped<IRepositoryLogin, RepositoryLogin>();
         }
    }
}
