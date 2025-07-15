using FutScore.Modelos;

namespace FutScore.Contracts.Jogador;

public record JogadorResponse(int Id, string Nome, string Posicao, int Gols, string NomeDoTime);
