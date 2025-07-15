using FutScore.Contracts.Transferencia;
using FutScore.Data;

namespace FutScore.API.Endpoints;

public static class TransferenciaExtensions
{
    public static void AddEndpointsTransferencias(this WebApplication app)
    {
        app.MapPost("/transferencias", (TransferenciaRequest request, TransferenciaService servico) =>
        {
            // O endpoint delega TODA a lógica para o serviço
            var resultado = servico.Executar(request);

            // Se o serviço retornou uma string de erro, devolve um 400 Bad Request
            if (!string.IsNullOrEmpty(resultado))
            {
                return Results.BadRequest(new { Erro = resultado });
            }

            // Se não, a operação foi um sucesso
            return Results.Ok("Transferência realizada com sucesso!");
        });
    }
}
