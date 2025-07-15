using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutScore.Modelos;
using FutScore.Contracts.Transferencia;

namespace FutScore.Data;
public class TransferenciaService
{
    private readonly JogadorRepository _repoJogador;
    private readonly TimeRepository _repoTime;
    private readonly DAL<Partida> _repoPartida; // Exemplo de outra dependência

    // Ele pede as ferramentas (repositórios) que precisa via Injeção de Dependência
    public TransferenciaService(JogadorRepository repoJogador, TimeRepository repoTime, DAL<Partida> repoPartida)
    {
        _repoJogador = repoJogador;
        _repoTime = repoTime;
        _repoPartida = repoPartida;
    }

    // Método principal que executa a lógica de negócio
    public string? Executar(TransferenciaRequest request)
    {
        // 1. Validações (seu código aqui está perfeito)
        var jogador = _repoJogador.RecuperarPor(j => j.Id == request.JogadorId);
        if (jogador == null) return "Erro: Jogador não encontrado.";

        var timeDestino = _repoTime.RecuperarPor(t => t.Id == request.TimeDestinoId);
        if (timeDestino == null) return "Erro: Time de destino não encontrado.";

        if (jogador.TimeId == request.TimeDestinoId)
        {
            return $"Erro: O jogador {jogador.Nome} já está no {timeDestino.Nome}.";
        }

        // 2. Executar a operação (Apenas mude a propriedade do objeto vigiado)
        jogador.TimeId = request.TimeDestinoId;

        // A linha _repoJogador.Atualizar(jogador); foi REMOVIDA.

        // 3. Salvar a mudança que o EF Core já detectou automaticamente.
        _repoJogador.Salvar();

        return null; // Retorna null para indicar sucesso
    }
}
