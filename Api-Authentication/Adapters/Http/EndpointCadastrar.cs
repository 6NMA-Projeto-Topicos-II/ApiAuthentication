using Api_Authentication.Domain.DTO;

namespace Api_Authentication.Adapters.Http
{
    public static class EndpointCadastrar
    {
        public static void AddEndpointCadastro(this WebApplication app)
        {
            app.MapPost("/v1/Cadastrar", async Task<IResult> (ResquestCadastrarUsuario request) =>
            {
                return Results.Ok(request);
            });
        }
    }
}
