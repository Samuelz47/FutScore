namespace FutScore.API.DTOs.Time;

public record TimeResponse(int Id, string Nome, int Pontos, int SaldoDeGols, int GolsFeitos, int GolsSofridos);
