using Api_Authentication.Adapters.Sql.ModelsSql;
using Api_Authentication.Domain.DTO;

namespace Api_Authentication.Port.OutboundPort
{
    public interface IRepository
    {
        public Task<string> InsertUsers(InputRegisterUser request);
        public Task<List<Usuario>> QueryUsersRegistration(InputLoginUser request);
    }
}
