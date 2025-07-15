using FutScore.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FutScore.Data;

public class PartidaRepository : DAL<Partida>
{
    private readonly FutScoreDbContext _context;

    public PartidaRepository(FutScoreDbContext context) : base(context)
    {
        _context = context;
    }

    // Método especializado para listar as partidas e JÁ INCLUIR os dados dos times
    public IEnumerable<Partida> ListarComTimes()
    {
        // Inclui os dados dos times da casa e de fora na consulta ao banco
        return _context.Partidas.Include(p => p.Casa).Include(p => p.Fora).ToList();
    }
}
