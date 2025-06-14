using ContabilidadeBeatyBeach.Domain.Entity;

namespace ContabilidadeBeatyBeach.Repository.Interface
{
    public interface IComissoesRepository
    {
        public Task<Comissoes> AdicionarComissaoAsync(Comissoes comissoes);

        public Task<Comissoes> ObterPorIdAsync(int id);

        public Task<List<Comissoes>> ObterComissoesPorUsuarioEMesAsync(int userId, string mesAno);

        public Task<List<Comissoes>> ObterComissoesPorUsuarioAsync(int userId);

        public Task<Comissoes> AtualizarComissaoAsync(Comissoes comissoes);

        public Task<bool> DeletarComissaoAsync(int id);
    }
}
