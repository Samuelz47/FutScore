using Contracts.Partida;
using FutScore.Data;

namespace FutScore.API.Endpoints;

public static class PartidaExtensions
{
    public static void AddEndpointsPartidas(this WebApplication app)
    {
        var group = app.MapGroup("/partidas");

        // Endpoint para listar TODAS as partidas
        // Rota: GET /partidas
        group.MapGet("", (PartidaRepository repo) =>
        {
            var partidas = repo.ListarComTimes();

            if (!partidas.Any())
            {
                return Results.NoContent(); // Retorna 204 No Content se não houver partidas
            }

            // Mapeia cada objeto Partida para um objeto PartidaResponse
            var response = partidas.Select(p => new PartidaResponse(p.Id, p.Casa.Nome, p.Fora.Nome, p.GolsCasa, p.GolsFora));

            return Results.Ok(response);
        });
    }
}
