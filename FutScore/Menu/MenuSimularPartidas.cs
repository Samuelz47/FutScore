using FutScore.Data;
using FutScore.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Menu;

internal class MenuSimularPartidas : Menu
{
    public void Executar(Campeonato campeonato, TimeRepository repoTime, DAL<Partida> repoPartida)
    {
        Console.Clear();
        base.ExibirTituloDaOpcao("Simular Partidas");
        if (campeonato == null || campeonato.Times.Count < 2)
        {
            Console.WriteLine("Não há times o suficiente para as partidas serem simuladas");
            Console.ReadKey();
            return;
        }
        Console.WriteLine("\nAperte qualquer tecla para iniciar as simulações");
        Console.ReadKey();

        var partidasDaRodada = new List<Partida>();
        int jogo = 1;
        for (int i = 0; i < campeonato.Times.Count; i++)                                // Loop para o time da casa
        {
            for (int j = 0; j < campeonato.Times.Count; j++)                            // Loop para o time de fora
            {
                if (i == j)                                                             // Um time não joga contra si mesmo
                {
                    continue;
                }

                Time timeCasa = campeonato.Times[i];
                Time timeFora = campeonato.Times[j];

                Console.WriteLine($"\nJogo {jogo}: {timeCasa.Nome} (Casa) vs {timeFora.Nome} (Fora)");
                Partida novaPartida = new Partida(timeCasa, timeFora);
                novaPartida.SimularPartida();
                novaPartida.CampeonatoId = campeonato.Id;
                partidasDaRodada.Add(novaPartida);
                jogo++;
            }
        }

        foreach (var partida in partidasDaRodada)
        {
            repoPartida.Adicionar(partida);
        }
        foreach (var time in campeonato.Times)
        {
            repoTime.Atualizar(time);
        }
        repoTime.Salvar();

        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu inicial");
        Console.ReadKey();
        Console.Clear();
    }
}
