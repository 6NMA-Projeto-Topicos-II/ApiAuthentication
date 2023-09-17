using Api_Authentication.Domain.DTO;
using Api_Authentication.Domain.Exceptions;
using Api_Authentication.Port.InputboundPort;
using Api_Authentication.Port.OutboundPort;
using Api_Authentication.Validation;

namespace Api_Authentication.Application.UseCase
{
    public class UseCaseRegister : IUseCaseRegister
    {
        private readonly IRepository _repository;
        public UseCaseRegister(IRepository repository) => _repository = repository;

        public async Task<string> Execute(InputRegisterUser request)
        {
            var retRepository = await _repository.QueryUsers(request);

            if (retRepository.Count() != 0)
            {
                if (retRepository.Select(x => x.Matricula).First() == request.Registration)
                {
                    throw new BusinessException("Registration already registered");
                }
                if (retRepository.Select(x => x.Email).First() == request.Email)
                {
                    throw new BusinessException("Email already registered");
                }
            }

            var ret = await _repository.InsertUsers(request);

            return ret;
        }
    }
}
