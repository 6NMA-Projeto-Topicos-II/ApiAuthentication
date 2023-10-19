using Api_Authentication.Domain.DTO;
using Api_Authentication.Domain.Exceptions;
using Api_Authentication.Domain.Validation;
using Api_Authentication.Port.InputboundPort;
using Api_Authentication.Port.OutboundPort;

namespace Api_Authentication.Domain.Application.UseCase
{

    public class UseCaseLogin : IUseCaseLogin
    {
        private readonly IRepository _repository;
        public UseCaseLogin(IRepository repository)
        {
            _repository = repository;
        }



        public async Task<string> Execute(InputLoginUser request)
        {
            var retRepository = await _repository.QueryUsersRegistration(request);
            if (retRepository.Count() != 0)
            {
                if (retRepository.Select(x => x.matricula).First() != request.Registration)
                {
                    throw new BusinessException("Matrícula Inválida");
                }
                if (retRepository.Select(y => y.senha).First() != request.Password)
                {
                    throw new BusinessException("Senha Inválida");
                }
            }
            else
            {
                throw new BusinessException("Matrícula Inválida");
            }


            var ret = "Autorização realizada com sucesso!!!";

            return ret;
        }
    }

}
