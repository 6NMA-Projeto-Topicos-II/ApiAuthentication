using Api_Authentication.Domain.DTO;

namespace Api_Authentication.Port.OutboundPort
{
    public interface IRepositoryLogin
    {
        public Task<IEnumerable<dynamic>> QueryUsersLogin(InputLoginUser request);


    }
}

