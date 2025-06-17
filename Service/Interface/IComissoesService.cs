using ContabilidadeBeatyBeach.Domain.Entity;

namespace ContabilidadeBeatyBeach.Service.Interface
{
    public interface IComissoesService
    {
        Task<Comissoes> AdicionarComissao (Comissoes comissoes);
    }
}
