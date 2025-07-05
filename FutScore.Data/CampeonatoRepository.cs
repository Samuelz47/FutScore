using FutScore.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Data;

public class CampeonatoRepository : DAL<Campeonato>
{
    private readonly FutScoreDbContext _context;

    public CampeonatoRepository(FutScoreDbContext context) : base(context)
    {
        _context = context;
    }
    public Campeonato? ObterCampeonatoCompleto(int id)
    {
        return _context.Campeonatos
            .Include(c => c.Times)              // 1. Inclui a lista de Times do campeonato
                .ThenInclude(t => t.Elenco)     // 2. PARA CADA Time, inclui a lista de Jogadores (Elenco)
            .Include(c => c.Partidas)           // 3. Inclui também a lista de Partidas do campeonato
            .FirstOrDefault(c => c.Id == id);   // 4. Filtra para pegar o campeonato com o ID que queremos
    }
}
