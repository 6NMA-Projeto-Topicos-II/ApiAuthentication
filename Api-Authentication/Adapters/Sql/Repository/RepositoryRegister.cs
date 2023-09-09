using Api_Authentication.Adapters.Sql.Connections;
using Api_Authentication.Domain.DTO;
using Api_Authentication.Port.OutboundPort;
using Dapper;

namespace Api_Authentication.Adapters.Sql.Repository
{
    public class RepositoryRegister : IRepositoryRegister
    {
        private readonly SQLContext _context;
        public RepositoryRegister(SQLContext context)
        {
            _context = context;
        }
        public async Task<string> InsertUsers(InputRegisterUser request)
        {
            using (var connect = _context.ConnectLocal())
            {
                var call = $"INSERT INTO tbl_Usuarios VALUES ('{request.Registration}','{request.Name}','{request.LastName}','{request.Email}','{request.Password}','{DateTime.Now.ToString()}')";

                await connect.QueryAsync(call);

                return "Cadastro realizado com sucesso";
            }
        }

        public async Task<IEnumerable<dynamic>> QueryUsers(InputRegisterUser request)
        {
            using (var connect = _context.ConnectLocal())
            {
                var call = $"SELECT * FROM tbl_Usuarios where Matricula = '{request.Registration}' OR Email = '{request.Email}'";

                var ret = await connect.QueryAsync(call);

                return ret;
            }
        }
    }
}
