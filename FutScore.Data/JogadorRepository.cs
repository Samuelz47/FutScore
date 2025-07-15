using FutScore.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Data;

public class JogadorRepository : DAL<Jogador>
{
    private readonly FutScoreDbContext _context;
    public JogadorRepository(FutScoreDbContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<Jogador> ListarPorTime(int timeId)
    {
        return _context.Jogadores.Include(j => j.Time).Where(j => j.TimeId == timeId).ToList();
    }

    public Jogador? RecuperarPorIdNoTime(int timeId, int jogadorId)
    {
        return _context.Jogadores.Include(j => j.Time).FirstOrDefault(j => j.Id == jogadorId && j.TimeId == timeId);
    }
}