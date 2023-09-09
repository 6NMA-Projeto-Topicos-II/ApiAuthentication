using Api_Authentication.Adapters.Sql;
using Api_Authentication.Adapters.Sql.Connections;
using Microsoft.Extensions.DependencyInjection;

namespace Api_Authentication.Infrastructure.Extensions
{
    public static class SQLExtensions
    {
        public void AddSqlExtensions(this ServiceCollection service,IConfiguration configuration)
        {
            service.AddSingleton(configuration.GetSection("SqlConnect").Get<ConnectionStrings>());
            service.AddSingleton<SQLContext>();
         }
    }
}
