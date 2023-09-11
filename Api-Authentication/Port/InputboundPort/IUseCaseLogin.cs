using Api_Authentication.Domain.DTO;

namespace Api_Authentication.Port.InputboundPort
{
    public interface IUseCaseLogin
    {
        public Task<string> Execute(InputLoginUser request);
    }
}
