using Api_Authentication.Domain.DTO;

namespace Api_Authentication.Adapters.Http
{
    public static class EndpointRegister
    {
        public static void AddEndpointRegister(this WebApplication app)
        {
            app.MapPost("/v1/Register", async Task<IResult> (InputRegisterUser request) =>
            {
                return Results.Ok(request);
            });
        }
    }
}
