using FutScore.Modelos;

namespace FutScore.API.DTOs.Jogador;

public record JogadorResponse(int Id, string Nome, string Posicao, int Gols, string NomeDoTime);
