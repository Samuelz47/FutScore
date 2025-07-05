using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Modelos;

public class Partida
{
    public int CampeonatoId { get; set; }                                           // Chave estrangeira que aponta para o ID do Campeonato
    public virtual Campeonato Campeonato { get; set; }                              // Propriedade de Navegação
    public Partida() { }
    public Partida(Time casa, Time fora)
    {
        Casa = casa;
        Fora = fora;
    }

    public int Id { get; set; }
    public Time Casa { get; set; }
    public Time Fora { get; set; }
    public int GolsCasa { get; set; }
    public int GolsFora { get; set; }

    public void SimularPartida()
    {
        Random random = new Random();
        int forcaCasaPorcentagem = ((Casa.Forca + 10) * 100) / (Casa.Forca + 10 + Fora.Forca);
        int forcaForaPorcentagem = (Fora.Forca * 100) / (Casa.Forca + 10 + Fora.Forca);
        int golsTotal = random.Next(0, 7);

        for (int g = 0; g < golsTotal; g++)
        {
            int definirGol = random.Next(0, 100);
            if (definirGol < forcaCasaPorcentagem)
            {
                GolsCasa++;
            }
            else
            {
                GolsFora++;
            }
        }
        DefinirGol();
        DistribuiPontuacao();

        Console.WriteLine($"\n{Casa.Nome} {GolsCasa} x {GolsFora} {Fora.Nome}");
    }

    public void DefinirGol()
    { 
        if (GolsCasa > 0 || GolsFora > 0)
        {
            Console.WriteLine("Detalhes dos Gols:");
            if (GolsCasa > 0)
            {
                DefinirJogadores(GolsCasa, Casa);
            }
            if (GolsFora > 0)
            {
                DefinirJogadores(GolsFora, Fora);
            }
        }
    }

    public void DefinirJogadores(int gols, Time time)
    {
        Random random = new Random();

        for (int g = 0; g < gols; g++)
        {
            int definirGol = random.Next(0, 100);
            List<Jogador> jogadoresDaPosicao = null;

            if (definirGol <= 1)
            {
                jogadoresDaPosicao = time.Elenco.Where(jogador => jogador.Posicao == Posicao.Goleiro)
                                                .ToList();
            }
            else if (definirGol <= 5)
            {
                jogadoresDaPosicao = time.Elenco.Where(jogador => jogador.Posicao == Posicao.Lateral)
                                                .ToList();
            }
            else if (definirGol <= 13)
            {
                jogadoresDaPosicao = time.Elenco.Where(jogador => jogador.Posicao == Posicao.Zagueiro)
                                                .ToList();
            }
            else if (definirGol <= 21)
            {
                jogadoresDaPosicao = time.Elenco.Where(jogador => jogador.Posicao == Posicao.Volante)
                                                .ToList();
            }
            else if (definirGol <= 36)
            {
                jogadoresDaPosicao = time.Elenco.Where(jogador => jogador.Posicao == Posicao.MeioCampo)
                                                .ToList();
            }
            else if (definirGol <= 60)
            {
                jogadoresDaPosicao = time.Elenco.Where(jogador => jogador.Posicao == Posicao.Ponta)
                                                .ToList();
            }
            else
            {
                jogadoresDaPosicao = time.Elenco.Where(jogador => jogador.Posicao == Posicao.Centroavante)
                                                .ToList();
            }

            if (jogadoresDaPosicao != null && jogadoresDaPosicao.Any())
            {
                int artilharia = random.Next(0, jogadoresDaPosicao.Count);
                Console.WriteLine($"- Gol do {time.Nome}: {jogadoresDaPosicao[artilharia].Nome} ({jogadoresDaPosicao[artilharia].Posicao})");
                jogadoresDaPosicao[artilharia].RegistrarGol();
            }
            else if (time.Elenco.Any())
            {
                int artilharia = random.Next(0, time.Elenco.Count);
                Console.WriteLine($"- Gol do {Casa.Nome}: {time.Elenco[artilharia].Nome} ({time.Elenco[artilharia].Posicao}) (posição geral)");
                time.Elenco[artilharia].RegistrarGol();
            }
        }
    }
    public void DistribuiPontuacao()
    {
        if (GolsCasa > GolsFora)
        {
            Casa.Pontuacao += 3;
        }
        else if (GolsCasa == GolsFora)
        {
            Casa.Pontuacao++;
            Fora.Pontuacao++;
        }
        else
        {
            Fora.Pontuacao += 3;
        }
        Casa.GolsPro += GolsCasa;
        Casa.GolsContra += GolsFora;
        Fora.GolsPro += GolsFora;
        Fora.GolsContra += GolsCasa;
    }
}
