using Api_Authentication.Domain.DTO;

namespace Api_Authentication.Port.OutboundPort
{
    public interface IRepository
    {
        public Task<string> InsertUsers(InputRegisterUser request);
        public Task<IEnumerable<dynamic>> QueryUsers(InputRegisterUser request);
        public Task<IEnumerable<dynamic>> QueryUsers(InputLoginUser request);
    }
}
