using ContabilidadeBeatyBeach.Domain.Entity;

namespace ContabilidadeBeatyBeach.Service.Interface
{
    public interface IComissoesService
    {
        Task<Comissoes> AdicionarComissaoAsync (Comissoes comissoes);

        Task<List<Comissoes>> ObterComissoesPorUsuarioEMesAsync (int userId, string mesAno);    

        Task<Comissoes> DeletarComissaoAsync (int id);    
    }
}
