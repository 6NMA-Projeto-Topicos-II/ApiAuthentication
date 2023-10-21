using Api_Authentication.Adapters.Sql.Connections;
using Api_Authentication.Adapters.Sql.ModelsSql;
using Api_Authentication.Domain.DTO;
using Api_Authentication.Port.OutboundPort;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Api_Authentication.Adapters.Sql.Repository
{
    public class Repository : IRepository
    {
        private readonly SQLContext _contextDB;
        public Repository(SQLContext context)
        {
            _contextDB = context;
        }
        public async Task<string> InsertUsers(InputRegisterUser request)
        {
            
            var usuario = new Usuario
            {
                nome = request.Name,
                sobrenome = request.LastName,
                email = request.Email,
                matricula = request.Registration,
                senha = request.Password,
                datacriacao = DateTime.Now.ToString()
            };
            await _contextDB.AddAsync(usuario);
            await _contextDB.SaveChangesAsync();

            return "Cadastro realizado com sucesso";
            
        }

        public async Task<Usuario> QueryUsersRegistrationOrEmail(InputRegisterUser request)
        {

            try
            {
                var ret = await _contextDB.Usuarios!.Where(User => User.email == request.Email || User.matricula == request.Registration)
                 .FirstOrDefaultAsync();

                return ret;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }


        }

        public async Task<List<Usuario>> QueryUsersRegistration(InputLoginUser request)
        {
            var ret = await _contextDB.Usuarios!.Where(User =>  User.matricula == request.Registration)
                             .ToListAsync();

            return ret;
        }


    }
}
