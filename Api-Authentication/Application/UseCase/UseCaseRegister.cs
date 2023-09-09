using Api_Authentication.Domain.DTO;
using Api_Authentication.Port.InputboundPort;
using Api_Authentication.Port.OutboundPort;

namespace Api_Authentication.Application.UseCase
{
    public class UseCaseRegister : IUseCaseRegister
    {
        private readonly IRepositoryRegister _repository;
        public UseCaseRegister(IRepositoryRegister repository)
        {
            _repository = repository;
        }
        public async Task<string> Execute(InputRegisterUser request)
        {
            var retRepository = await _repository.QueryUsers(request);
            if (retRepository.Select(x => x.Matricula).First() == request.Registration)
            {
                return "Matricula Já cadastrada";
            }
            return "";
        }
    }
}
