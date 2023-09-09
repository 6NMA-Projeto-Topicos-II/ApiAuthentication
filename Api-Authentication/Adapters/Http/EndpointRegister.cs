using Api_Authentication.Domain.DTO;
using Api_Authentication.Domain.Exceptions;
using Api_Authentication.Port.InputboundPort;

namespace Api_Authentication.Adapters.Http
{
    public static class EndpointRegister
    {
        public static void AddEndpointRegister(this WebApplication app)
        {
            app.MapPost("/v1/Register", async Task<IResult> (InputRegisterUser request, IUseCaseRegister useCase) =>
            {
                try
                {
                    var ret= await useCase.Execute(request);
                    return Results.Ok(ret);
                }catch(BusinessException ex)
                {
                    return Results.Json(ex.Message,statusCode: 400);
                }
                catch (Exception ex) 
                {

                    return Results.Json(ex.Message, statusCode: 500);
                }
            });
        }
    }
}
