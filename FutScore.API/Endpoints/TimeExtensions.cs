using FutScore.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using FutScore.Contracts.Time;
using FutScore.Modelos;

namespace FutScore.API.Endpoints;

public static class TimeExtensions
{
    public static void AddEndpointsTimes(this WebApplication app)
    {
        app.MapGet("/Times", ([FromServices] TimeRepository repo) =>
        {
            var timeResponseList = repo.Listar()
                                       .Select(t => new TimeResponse(t.Id, t.Nome, t.Pontuacao, t.saldoDeGols, t.GolsPro, t.GolsContra)).ToList();

            return Results.Ok(timeResponseList);
        });

        app.MapGet("/Times/{nome}", ([FromServices] TimeRepository repo, string nome) =>
        {
            var time = repo.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (time == null)
            {
                return Results.NotFound();
            }
            var timeResponse = new TimeResponse(time.Id, time.Nome, time.Pontuacao, time.saldoDeGols, time.GolsPro, time.GolsContra);
            return Results.Ok(timeResponse);
        });
        app.MapPost("/Times", ([FromServices] TimeRepository repo, [FromBody] TimeRequest timeRequest) =>
        {
            var time = new Time(timeRequest.Nome, timeRequest.Forca);
            repo.Adicionar(time);
            repo.Salvar();
            var timeResponse = new TimeResponse(time.Id, time.Nome, time.Pontuacao, time.saldoDeGols, time.GolsPro, time.GolsContra);
            return Results.Created($"/Times/{time.Id}", timeResponse);
        });
        app.MapDelete("/Times/{id}", ([FromServices] TimeRepository repo, int id) =>
        {
            var time = repo.RecuperarPor(a => a.Id == id);
            if (time == null)
            {
                return Results.NotFound();
            }
            repo.Deletar(time);
            repo.Salvar();
            return Results.NoContent();
        });
        app.MapPut("/Times/{id}", (int id, [FromServices] TimeRepository repo, [FromBody] TimeRequestEdit timeRequestEdit) =>
        {
            var timeAAtualizar = repo.RecuperarPor(a => a.Id == id);
            if (timeAAtualizar == null)
            {
                return Results.NotFound();
            }
            timeAAtualizar.Forca = timeRequestEdit.Forca;

            repo.Atualizar(timeAAtualizar);
            repo.Salvar();
            return Results.NoContent();
        });
    }
}
