using FutScore.Data;
using FutScore.Modelos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Menu;

internal class MenuExibirTime : Menu
{
    public void Executar(TimeRepository repoTime)
    {
        bool continuarExibindo = true;
        Time timeProcurado = null;

        while (continuarExibindo)
        {
            Console.Clear();
            base.ExibirTituloDaOpcao("Exibir Time");

            string nomeDoTime;
            while (true)
            {
                Console.WriteLine("Digite o Nome do time a ser exibido: ");
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

            timeProcurado.ExibirEstatisticas();
            Console.WriteLine();
            timeProcurado.ExibirElenco();
            Console.WriteLine("\nDeseja exibir outro time?");
            Console.WriteLine("1 -- Sim");
            Console.WriteLine("Qualquer outra tecla - Não (Voltar ao Menu Principal)");
            string? escolhaFinalInput = Console.ReadLine();

            if (escolhaFinalInput == "1")
            {
                continuarExibindo = true;
            }
            else
            {
                Console.Clear();
                continuarExibindo = false;
            }
        }
    }
}
