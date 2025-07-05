using FutScore.Menu;
using FutScore.Modelos;
using FutScore.Data;
using System.Threading.Tasks.Dataflow;
using System.ComponentModel.DataAnnotations;

while (true)
{
    try
    {
        int idDoCampeonato = 1;
        using var context = new FutScoreDbContext();
        var repoCampeonato = new CampeonatoRepository(context);
        var campeonatoCompleto = repoCampeonato.ObterCampeonatoCompleto(idDoCampeonato);
        var repoTime = new TimeRepository(context);
        var repoJogador = new DAL<Jogador>(context);
        var repoPartida = new DAL<Partida>(context);

        ExibirLogo();
        OpcoesDeMenu();

        string? inputDoUsuario = Console.ReadLine();

        if (int.TryParse(inputDoUsuario, out int opcaoEscolhida))
        {
            switch (opcaoEscolhida)
            {
                case 1:
                    MenuRegistrarTime registrarTime = new MenuRegistrarTime();
                    registrarTime.Executar(repoTime);
                    break;
                case 2:
                    MenuRegistrarJogadores registrarJogador = new MenuRegistrarJogadores();
                    registrarJogador.Executar(repoTime, repoJogador);
                    break;
                case 3:
                    MenuSimularPartidas simularPartidas = new MenuSimularPartidas();
                    simularPartidas.Executar(campeonatoCompleto, repoTime, repoPartida);
                    break;
                case 4:
                    MenuSimularPartida simularPartida = new MenuSimularPartida();
                    simularPartida.Executar(idDoCampeonato, repoPartida, repoTime);
                    break;
                case 5:
                    MenuExibirTime exibirTime = new MenuExibirTime();
                    exibirTime.Executar(repoTime);
                    break;
                case 6:
                    MenuExibirClassificacao exibirClassificacao = new MenuExibirClassificacao();
                    exibirClassificacao.Executar(campeonatoCompleto);
                    break;
                case 7:
                    MenuExibirEstatisticas exibirEstatisticas = new MenuExibirEstatisticas();
                    exibirEstatisticas.Executar(campeonatoCompleto);
                    break;
                case -1:
                    Console.WriteLine("Obrigado por usar o FutScore");
                    return;
                    break;
                default:
                    Console.WriteLine("Opcao inválida, 3novamente");
                    break;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);

        Exception inner = ex.InnerException;
        int level = 1;
        while (inner != null)
        {
            Console.WriteLine($"\n--> Causa Interna (Nível {level}): {inner.Message}");
            inner = inner.InnerException;
            level++;
        }
        Console.ResetColor();
        Console.WriteLine("\nO programa encontrou um erro e será finalizado. Pressione qualquer tecla para sair.");
        Console.ReadKey();
    }
}

void ExibirLogo()
{
    Console.WriteLine($"███████╗██╗   ██╗████████╗███████╗ ██████╗ ██████╗ ██████╗ ███████╗\r\n██╔════╝██║   ██║╚══██╔══╝██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔════╝\r\n█████╗  ██║   ██║   ██║   ███████╗██║     ██║   ██║██████╔╝█████╗  \r\n██╔══╝  ██║   ██║   ██║   ╚════██║██║     ██║   ██║██╔══██╗██╔══╝  \r\n██║     ╚██████╔╝   ██║   ███████║╚██████╗╚██████╔╝██║  ██║███████╗\r\n╚═╝      ╚═════╝    ╚═╝   ╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝");
    Console.WriteLine("Seja Bem vindo ao FutScore");
}
void OpcoesDeMenu()
{
    Console.WriteLine("\n1 -- para registrar um time");
    Console.WriteLine("2 -- para registrar os jogadores");
    Console.WriteLine("3 -- para simular partidas");
    Console.WriteLine("4 -- para simular partida");
    Console.WriteLine("5 -- para exibir time");
    Console.WriteLine("6 -- para exibir classificação do grupo");
    Console.WriteLine("7 -- para exibir estatísticas");
    Console.WriteLine("-1 -- para sair");
}