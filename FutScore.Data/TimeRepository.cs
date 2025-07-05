using FutScore.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutScore.Data;

public class TimeRepository : DAL<Time>
{
    private readonly FutScoreDbContext _context;

    // O construtor passa o context para a classe base DAL
    public TimeRepository(FutScoreDbContext context) : base(context)
    {
        _context = context;
    }

    // MÉTODO ESPECÍFICO E ESSENCIAL:
    public Time? ObterTimeCompletoPeloNome(string nome)
    {
        // AQUI ESTÁ A SOLUÇÃO: .Include(t => t.Elenco)
        // Isso força o EF Core a carregar a lista de jogadores do time.
        return _context.Times
                       .Include(t => t.Elenco)
                       .FirstOrDefault(t => t.Nome.ToUpper() == nome.ToUpper());
    }
}