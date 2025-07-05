using FutScore.Data;
using FutScore.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Menu;

internal class MenuRegistrarTime : Menu
{
    public void Executar(TimeRepository repoTime)
    {
        bool continuarRegistrando = true;

        while (continuarRegistrando)
        {
            Console.Clear();
            base.ExibirTituloDaOpcao("Registrar Time");

            string nomeDoTime;
            while (true)
            {
                Console.WriteLine("Digite o Nome do time a ser registrado: ");
                nomeDoTime = Console.ReadLine()!;
                if (repoTime.RecuperarPor(p => p.Nome.Equals(nomeDoTime, StringComparison.OrdinalIgnoreCase)) != null)
                {
                    Console.WriteLine("Time já está registrado, digite outro time");
                }
                else
                {
                    break;
                }
            }
            int forcaDoTime;
            while (true)
            { 
                Console.WriteLine("Agora digite a força desse time entre 1 e 100: ");
                string inputDoUsuario = Console.ReadLine()!;

                if (int.TryParse(inputDoUsuario, out forcaDoTime) && forcaDoTime > 0 && forcaDoTime < 101)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Valor da força inválido, digite novamente");
                }
            }
            Time novoTime = new Time(nomeDoTime, forcaDoTime);
            repoTime.Adicionar(novoTime);
            repoTime.Salvar();
            Console.WriteLine($"Time {novoTime.Nome} Registrado com sucesso!");

            Console.WriteLine("\nDeseja registrar outro time?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("Qualquer outra tecla - Não (Voltar ao Menu Principal)");
            string? escolhaFinalInput = Console.ReadLine();

            if (escolhaFinalInput == "1")
            {
                continuarRegistrando = true;
            }
            else
            {
                Console.Clear();
                continuarRegistrando = false;
            }
        }
    }
}
