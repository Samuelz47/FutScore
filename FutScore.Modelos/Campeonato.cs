using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Modelos;

public class Campeonato
{
    public Campeonato() { }
    public List<Time> Times { get; set; } = new List<Time>();
    public List<Partida> Partidas { get; set; } = new List<Partida>();
    public string Nome { get; set; }
    public int Id { get; set; }
    public Campeonato(string nome)
    {
        Nome = nome;
    }


    public void AdicionarTime(Time time)
    {
        Times.Add(time);
    }

    public void AdicionarJogos(Partida partida)
    {
        Partidas.Add(partida);
    }

    public void ExibirClassificacao()
    {
        var classificacao = Times.OrderByDescending(p => p.Pontuacao)
                                 .ThenByDescending(p => p.SaldoDeGols)
                                 .ThenByDescending(p => p.GolsPro)
                                 .ToList();
        int posicao = 1;
        foreach (var time in classificacao)
        {
            Console.WriteLine($"{posicao++}º - {time.Nome} | Pontos: {time.Pontuacao}, Saldo: {time.saldoDeGols}, Gols Feitos: {time.GolsPro}, Gols Sofridos: {time.GolsContra}");
        }
    }

    public void ExibirArtilharia()
    {
        var jogadores = Times.SelectMany(p => p.Elenco)
                             .ToList();

        var artilharia = jogadores.Where(p => p.Gols > 0)
                                     .OrderByDescending(p => p.Gols)
                                     .ToList();

        Console.WriteLine("--- ARTILHARIA DO CAMPEONATO ---");
        int posicaoTabela = 1;
        foreach (var jogador in artilharia)
        {
            Console.WriteLine($"{posicaoTabela}º - {jogador.Nome} - {jogador.Gols} gol(s)");
            posicaoTabela++;
        }

    }

}
