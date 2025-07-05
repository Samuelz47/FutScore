using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Modelos;

public class Time
{
    public int CampeonatoId { get; set; }                                       // Chave estrangeira que aponta para o ID do Campeonato
    public virtual Campeonato Campeonato { get; set; }                          // Propriedade de Navegação
    public Time() { }
    public Time(string nome, int forca)
    {
        Nome = nome;
        Forca = forca;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Jogador> Elenco { get; set; } = new List<Jogador>();                    //Pra lista não ficar null
    public int Pontuacao { get; set; }
    public int GolsPro {  get; set; }
    public int GolsContra { get; set; }
    public int SaldoDeGols { get; set; }
    public int saldoDeGols => GolsPro - GolsContra;

    private int _forca;                                                                 //Campo privado para guardar o valor da força.
    public int Forca                                                                    //Propriedade pública 'Forca' com lógica no 'set'.
    {
        get
        {
            return _forca;
        }
        set
        {
            if (value >= 1 && value <= 100)
            {
                _forca = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), "O valor da Força deve ser entre 1 e 100.");
            }
        }
    }

    public void AdicionarJogador(Jogador jogador)
    {
        Elenco.Add(jogador);
    }

    public void ExibirElenco()
    {
        var listaOrdenadaPorPosicao = Elenco.OrderBy(x => x.Posicao).ToList();
        Console.WriteLine($"Elenco do {Nome}");
        foreach (var jogador in listaOrdenadaPorPosicao)
        {
            Console.WriteLine($"{jogador.Nome} -- {jogador.Posicao}");
        }
    }

    public void ExibirEstatisticas()
    {
        Console.WriteLine($"O time {Nome} está com {Pontuacao} pontos, {GolsPro} gols marcados, {GolsContra} gols sofridos e {saldoDeGols}");
    }

}
