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

                if (retRepository.Count() == 0 || request.Registration == null || request.Password == null)
                {
                    if (retRepository.Select(x => x.Matricula).First() != request.Registration && retRepository.Select(y => y.Senha).First() != request.Password)
                    {
                        throw new BusinessException("Matricula ou senha inválidos");
                    }
                }

                //var ret = await _repository.InsertUsers(request);
                //var ret = await _repository.

                return "Autorização realizada com sucesso!!!";
            }
        }

    }
