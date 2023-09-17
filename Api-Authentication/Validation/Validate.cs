using Api_Authentication.Domain.DTO;
using Api_Authentication.Domain.Exceptions;
using Azure.Core;

namespace Api_Authentication.Validation
{
    public static class Validate
    {

        public static void ValidaRequest(InputLoginUser request)
        {
            if (string.IsNullOrEmpty(request.Registration) || string.IsNullOrWhiteSpace(request.Registration))
            {
                throw new BusinessException("Matrícula Inválida!");
            }
            if (string.IsNullOrEmpty(request.Password) || string.IsNullOrWhiteSpace(request.Password))
            {
                throw new BusinessException("Senha Inválida!");
            }
        }


    }
}