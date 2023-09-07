using Api_Authentication.Domain.DTO;

namespace Api_Authentication.Port.InputboundPort
{
    public interface IUseCaseRegister
    {
        public Task<string> Execute(InputRegisterUser request);
    }
}
