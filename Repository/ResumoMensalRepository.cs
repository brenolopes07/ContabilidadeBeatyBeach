using ContabilidadeBeatyBeach.Data;
using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadeBeatyBeach.Repository
{
    public class ResumoMensalRepository : IResumoMensal
    {
        private readonly AppDbContext _context;

        public ResumoMensalRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResumoMensal?> ObterPorUsuarioEMesAsync(int usuarioId, string mes)
        {
            return await _context.ResumoMensal
                .FirstOrDefaultAsync(r => r.UsuarioId == usuarioId && r.Mes == mes);
        }

        public async Task<List<ResumoMensal>> ObterPorUsuarioAsync(int usuarioId)
        {
            return await _context.ResumoMensal
                .Where(r => r.UsuarioId == usuarioId)
                .OrderByDescending(r => r.Mes)
                .ToListAsync();
        }

        public async Task<ResumoMensal> CriarAsync(ResumoMensal resumoMensal)
        {
            _context.ResumoMensal.Add(resumoMensal);
            await _context.SaveChangesAsync();
            return resumoMensal;
        }

        public async Task<ResumoMensal> AtualizarAsync(ResumoMensal resumomensal) 
        {
            _context.ResumoMensal.Update(resumomensal);
            await _context.SaveChangesAsync();
            return resumomensal;
        }
    }
}
