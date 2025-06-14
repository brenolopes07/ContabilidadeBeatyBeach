using ContabilidadeBeatyBeach.Data;
using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadeBeatyBeach.Repository
{
    public class ComissoesRepository : IComissoesRepository
    {
        private readonly AppDbContext _context;

        public ComissoesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comissoes> AdicionarComissaoAsync (Comissoes comissoes)
        {
            _context.Comissoes.Add(comissoes);
            await _context.SaveChangesAsync();
            return comissoes;
        }

        public async Task<Comissoes> AtualizarComissaoAsync(Comissoes comissoes)
        {
            _context.Comissoes.Update(comissoes);
            await  _context.SaveChangesAsync();
            return comissoes;
        }
       

        public async Task<List<Comissoes>> ObterComissoesPorUsuarioAsync(int userId)
        {
            return await _context.Comissoes
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.Data)
                .ToListAsync();
        }

        public async Task<List<Comissoes>> ObterComissoesPorUsuarioEMesAsync(int userId, string mesAno)
        {
            var partes = mesAno.Split('-');
            int ano = int.Parse(partes[0]);
            int mes = int.Parse(partes[1]);

            var dataInicio = new DateTime(ano, mes, 1);
            var dataFim = dataInicio.AddMonths(1);

            return await _context.Comissoes
                .Where(c => c.UserId == userId && c.Data >= dataInicio && c.Data < dataFim)
                .OrderByDescending(c => c.Data)
                .ToListAsync();
        }

        public async Task<Comissoes> ObterPorIdAsync(int id)
        {
            return await _context.Comissoes.FindAsync(id);
        }

        public async Task<bool> DeletarComissaoAsync(int id)
        {
            var comissao = await ObterPorIdAsync(id);
            if (comissao == null) return false;

            _context.Comissoes.Remove(comissao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
