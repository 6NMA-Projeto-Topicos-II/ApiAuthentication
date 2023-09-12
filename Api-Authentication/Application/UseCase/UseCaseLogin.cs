using Api_Authentication.Domain.DTO;
using Api_Authentication.Domain.Exceptions;
using Api_Authentication.Port.InputboundPort;
using Api_Authentication.Port.OutboundPort;

namespace Api_Authentication.Application.UseCase
{

        public class UseCaseLogin : IUseCaseLogin
        {
            private readonly IRepositoryLogin _repository;
            public UseCaseLogin(IRepositoryLogin repository)
            {
                _repository = repository;
            }

            
            

            public async Task<string> ExecuteLogin(InputLoginUser request)
            {
                var retRepository = await _repository.QueryUsersLogin(request);


                if (retRepository.Count() != 0)
                {
                    if (retRepository.Select(x => x.Matricula).First() != request.Registration)
                    {
                        throw new BusinessException("Matrícula Inválida");
                    }
                    if (retRepository.Select(y => y.Senha).First() != request.Password)
                    {
                        throw new BusinessException("Senha Inválida");
                    }
                } else
                {
                    throw new BusinessException("Matrícula Inválida");
                }


                var ret = "Autorização realizada com sucesso!!!";

                return ret;
            }
        }

    }
