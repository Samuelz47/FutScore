using FutScore.Contracts.Jogador;
using FutScore.Data;
using FutScore.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace FutScore.API.Endpoints;

public static class JogadorExtensions
{
    public static void AddEndpointsJogadores(this WebApplication app)
    {
        var group = app.MapGroup("/times/{timeId}/jogadores");

        // GET /times/{timeId}/jogadores
        group.MapGet("", (JogadorRepository repo, int timeId) =>
        {
            var jogadoresDoTime = repo.ListarPorTime(timeId);
            if (!jogadoresDoTime.Any()) return Results.NotFound("Nenhum jogador encontrado para este time.");

            var response = jogadoresDoTime.Select(j =>
                new JogadorResponse(j.Id, j.Nome, j.Posicao.ToString(), j.Gols, j.Time.Nome));

            return Results.Ok(response);
        });

        // POST /times/{timeId}/jogadores
        group.MapPost("", (int timeId, [FromBody] JogadorRequest request, TimeRepository repoTime) =>
        {
            var time = repoTime.RecuperarPor(t => t.Id == timeId);
            if (time is null) return Results.NotFound("Time não encontrado.");

            var novoJogador = new Jogador(request.Nome, request.posicao)
            {
                TimeId = timeId // Associando o jogador ao time
            };

            time.AdicionarJogador(novoJogador);
            repoTime.Atualizar(time);
            repoTime.Salvar();

            return Results.Created($"/jogadores/{novoJogador.Id}", new JogadorResponse(novoJogador.Id, novoJogador.Nome, novoJogador.Posicao.ToString(), novoJogador.Gols, time.Nome));
        });

        // DELETE /jogadores/{id} (Rota simplificada e mais correta)
        app.MapDelete("/jogadores/{id}", ([FromServices] DAL<Jogador> repo, int id) =>
        {
            var jogador = repo.RecuperarPor(a => a.Id == id);
            if (jogador is null) return Results.NotFound();

            repo.Deletar(jogador);
            repo.Salvar();
            return Results.NoContent();
        });

        // PUT /jogadores/{id} (Rota simplificada)
        app.MapPut("/jogadores/{id}", (int id, [FromBody] JogadorRequestEdit request, DAL<Jogador> repo) =>
        {
            var jogador = repo.RecuperarPor(a => a.Id == id);
            if (jogador is null) return Results.NotFound();

            jogador.Posicao = request.posicao;

            repo.Atualizar(jogador);
            repo.Salvar();
            return Results.NoContent();
        });
    }
}
