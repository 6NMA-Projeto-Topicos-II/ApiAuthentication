using Api_Authentication.Domain.DTO;
using Api_Authentication.Domain.Exceptions;
using Api_Authentication.Port.InputboundPort;
using Api_Authentication.Port.OutboundPort;

namespace Api_Authentication.Application.UseCase
{
    public class UseCaseRegister : IUseCaseRegister
    {
        private readonly IRepositoryRegister _repository;
        public UseCaseRegister(IRepositoryRegister repository) => _repository = repository;

        public async Task<string> Execute(InputRegisterUser request)
        {
            var retRepository = await _repository.QueryUsers(request);
            if(retRepository.Count() != 0)
            {
                if (retRepository.Select(x => x.Matricula).First() == request.Registration)
                {
                    throw new BusinessException( "Matricula Já cadastrada");
                }
                if (retRepository.Select(x => x.Email).First() == request.Email)
                {
                    throw new BusinessException("Email já cadastrado");
                }
            }

            var ret = await _repository.InsertUsers(request);

            return ret;
        }
    }
}
