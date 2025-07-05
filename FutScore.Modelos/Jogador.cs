using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Modelos;

public class Jogador
{
    public virtual Time Time { get; set; }      
    public int TimeId { get; set; }             // Esta propriedade vai guardar o ID do Time ao qual o jogador pertence. Sendo a foreign key
    public Jogador() { }                        //Construtor vazio para conseguir rodar a Migration
    public Jogador(string nome, Posicao posicao)
    {
        Nome = nome;
        Posicao = posicao;
    }
    public int Id { get; set; }
    public string Nome { get; set; }
    public Posicao Posicao  { get; set; }
    public int Gols { get; set; } = 0;
    
    public void RegistrarGol()
    {
        Gols++;
    }
}
