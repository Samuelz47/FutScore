using FutScore.Data;
using FutScore.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Menu;

internal class MenuSimularPartida : Menu
{
    public void Executar(int idDoCampeonato, DAL<Partida> repoPartida, TimeRepository repoTime)
    {
        bool continuarSimulando = true;
        Time casa;
        Time fora;
        while (continuarSimulando)
        {
            Console.Clear();
            base.ExibirTituloDaOpcao("Simular Partida");

            while (true)
            {
                Console.WriteLine("Digite o nome do Time que irá jogar em casa:");
                string? casaString = Console.ReadLine();
                casa = repoTime.ObterTimeCompletoPeloNome(casaString);

                if (casa != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Time não cadastrado, digite novamente");
                }
            }
            while (true)
            {
                Console.WriteLine("Digite o nome do Time que irá jogar em fora:");
                string? foraString = Console.ReadLine();
                fora = repoTime.ObterTimeCompletoPeloNome(foraString);

                if (fora != null)
                {
                    if (casa.Id == fora.Id)
                    {
                        Console.WriteLine("O time da casa não pode ser o mesmo que o de fora. Escolha outro.");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Time não cadastrado, digite novamente");
                }
            }

            Partida novaPartida = new Partida(casa, fora);
            novaPartida.SimularPartida();
            novaPartida.CampeonatoId = idDoCampeonato;  
            repoPartida.Adicionar(novaPartida);
            repoTime.Atualizar(casa);
            repoTime.Atualizar(fora);                   //Atualizando as pontuações, saldo de gols e etc dos times automaticamente o Entity já atualiza os gols dos jogadores já que temos a classe TimeRepository
            repoTime.Salvar();

            Console.WriteLine("Deseja simular outro jogo?");
            Console.WriteLine("1 -- Sim");
            Console.WriteLine("Qualquer outra tecla - Não (Voltar ao Menu Principal)");
            string? escolhaFinalInput = Console.ReadLine();

            if (escolhaFinalInput == "1")
            {
                continuarSimulando = true;
            }
            else
            {
                Console.Clear();
                continuarSimulando = false;
            }
        }
    }
}