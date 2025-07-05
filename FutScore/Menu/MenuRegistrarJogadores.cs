using FutScore.Data;
using FutScore.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Menu;

internal class MenuRegistrarJogadores : Menu
{
    public void Executar(TimeRepository repoTime, DAL<Jogador> repoJogador)
    {
        bool continuarRegistrando = true;
        Time timeProcurado = null;

        while (continuarRegistrando)
        {
            Console.Clear();
            base.ExibirTituloDaOpcao("Registrar Jogador");

            string nomeDoTime;
            while (timeProcurado == null)
            {
                Console.WriteLine("Digite o Nome do time a ser registrado: ");
                nomeDoTime = Console.ReadLine()!;
                timeProcurado = repoTime.ObterTimeCompletoPeloNome(nomeDoTime);
                if (timeProcurado != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Esse time ainda não foi registrado, digite outro");
                }
            }

            string nomeDoJogador;
            Posicao posicaoEscolhida;
            var posicoesDisponiveis = Enum.GetValues<Posicao>();
            Console.WriteLine($"Registrando Jogador no {timeProcurado.Nome}");
            Console.WriteLine("Digite o nome do jogdor a ser registrado");
            nomeDoJogador = Console.ReadLine()!;
            while (true)
            {
                Console.WriteLine("Qual a posição do jogador?");
                Console.WriteLine("Escolha uma das posições abaixo:");

                for (int i = 0; i < posicoesDisponiveis.Length; i++)
                {
                    Console.WriteLine($"[{i + 1}] - {posicoesDisponiveis[i]}");
                }

                Console.Write("Digite o número da posição: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int escolhaNumerica) && escolhaNumerica >= 1 && escolhaNumerica <= posicoesDisponiveis.Length)
                {
                    posicaoEscolhida = posicoesDisponiveis[escolhaNumerica - 1];
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
            }

            Jogador novoJogador = new Jogador(nomeDoJogador, posicaoEscolhida);
            timeProcurado.AdicionarJogador(novoJogador);
            repoTime.Atualizar(timeProcurado);
            repoTime.Salvar();

            Console.WriteLine("Deseja continuar registrando jogadores nesse time?");
            Console.WriteLine("1 -- Sim");
            Console.WriteLine("2 -- Sim, mas em outro clube");
            Console.WriteLine("Qualquer outra tecla pra sair.");

            string? escolhaFinalInput = Console.ReadLine();

            if (escolhaFinalInput == "1")
            {
                continue;

            }
            else if (escolhaFinalInput == "2")
            {
                timeProcurado = null;
                continue;
            }
            else
            {
                Console.Clear();
                break;
            }
        }
    }
}


