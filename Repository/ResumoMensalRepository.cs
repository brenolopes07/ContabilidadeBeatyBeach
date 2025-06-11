using ContabilidadeBeatyBeach.Data;
using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadeBeatyBeach.Repository
{
    public class ResumoMensalRepository : IResumoMensalRepository
    {
        private readonly AppDbContext _context;

        public ResumoMensalRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResumoMensal?> ObterPorUsuarioEMesAsync(int UserId, string mesAno)
        {
            return await _context.ResumoMensal              
                .FirstOrDefaultAsync(r => r.UserId == UserId && r.Mes == mesAno);
        }

        public async Task<List<ResumoMensal>> ObterPorUsuarioAsync(int UserId)
        {
            return await _context.ResumoMensal
                .Where(r => r.UserId == UserId)
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
