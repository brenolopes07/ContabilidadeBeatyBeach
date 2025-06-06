using ContabilidadeBeatyBeach.Data;
using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadeBeatyBeach.Repository
{
    public class HoraExtraRepository : IHoraExtraRepository
    {
        private readonly AppDbContext _context;

        public HoraExtraRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HoraExtra> ObterPorIdAsync(int id)
        {
            return await _context.HoraExtra.FindAsync(id);
        }

        public async Task<List<HoraExtra>> ObterPorUsuarioAsync(int userId)
        {
            return await _context.HoraExtra
                .Where(h => h.UserId == userId)
                .OrderByDescending(h => h.Data)
                .ToListAsync();
        }

        public async Task<List<HoraExtra>> ObterPorUsuarioEMesAsync(int userId, string data)
        {
            return await _context.HoraExtra
                .Where(h => h.UserId == userId && h.Data.ToString("yyyy-MM") == data)
                .OrderByDescending(h => h.Data)
                .ToListAsync();
        }

        public async Task<HoraExtra> CriarAsync(HoraExtra horaExtra)
        {
            _context.HoraExtra.Add(horaExtra);
            await _context.SaveChangesAsync();
            return horaExtra;
        }

        public async Task<HoraExtra> AtualizarAsync(HoraExtra horaExtra)
        {
            _context.HoraExtra.Update(horaExtra);
            await _context.SaveChangesAsync();
            return horaExtra;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var horaExtra = await ObterPorIdAsync(id);
            if (horaExtra == null) return false;
            _context.HoraExtra.Remove(horaExtra);
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
