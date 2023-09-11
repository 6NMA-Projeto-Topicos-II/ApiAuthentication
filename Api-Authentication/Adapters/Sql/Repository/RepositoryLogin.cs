using Api_Authentication.Adapters.Sql.Connections;
using Api_Authentication.Domain.DTO;
using Api_Authentication.Port.OutboundPort;
using Dapper;

namespace Api_Authentication.Adapters.Sql.Repository
{
    public class RepositoryLogin : IRepositoryLogin
    {
        private readonly SQLContext _context;

        public RepositoryLogin(SQLContext context)
        {
            _context = context;
        }

     
     

        // public async Task <string> TokenGeneration{ }

        public async Task<IEnumerable<dynamic>> QueryUsersLogin(InputLoginUser request)
        {
            using (var connect = _context.ConnectLocal())
            {
                var call = $"SELECT * FROM tbl_Usuarios where Matricula = '{request.Registration}";

                var ret = await connect.QueryAsync(call);

                return ret;
            }
        }
    }
}
