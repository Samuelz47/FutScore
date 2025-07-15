using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Partida;

public record PartidaResponse(int id, string TimeCasa, string TimeFora, int GolsCasa, int GolsFora);