using Api_Authentication.Domain.DTO;
using Api_Authentication.Domain.Exceptions;
using Api_Authentication.Port.InputboundPort;
using Api_Authentication.Port.OutboundPort;


namespace Api_Authentication.Domain.Application.UseCase
{
    public class UseCaseRegister : IUseCaseRegister
    {
        private readonly IRepository _repository;

        public UseCaseRegister(IRepository repository) => _repository = repository;

        public async Task<string> Execute(InputRegisterUser request)
        {
            var retRepository = await _repository.QueryUsersRegistrationOrEmail(request);

            if(retRepository != null)
            {
                if (retRepository.matricula == request.Registration)
                {
                    throw new BusinessException("Registration already registered");
                }
                if (retRepository.email == request.Email)
                {
                    throw new BusinessException("Email already registered");
                }
            }
            

            var ret = await _repository.InsertUsers(request);

            return ret;
        }
    }
}
