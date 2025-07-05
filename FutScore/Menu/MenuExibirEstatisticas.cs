using FutScore.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Menu;

internal class MenuExibirEstatisticas : Menu
{
    public void Executar(Campeonato campeonato)
    {
        Console.Clear();
        base.ExibirTituloDaOpcao("Artilharia");
        campeonato.ExibirArtilharia();
        Console.WriteLine("\nAperta qualquer tecla para voltar ao menu inicial");
        Console.ReadKey();
        Console.Clear();
    }
}
