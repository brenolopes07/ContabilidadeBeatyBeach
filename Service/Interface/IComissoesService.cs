using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.DTOs.ComissoesDTO;

namespace ContabilidadeBeatyBeach.Service.Interface
{
    public interface IComissoesService
    {
        Task<CriarComissaoOutputDTO> AdicionarComissaoAsync (Comissoes comissoes);

        Task<List<Comissoes>> ObterComissoesPorUsuarioEMesAsync (int userId, string mesAno);    

        Task<Comissoes> DeletarComissaoAsync (int id);    

        decimal CalcularTotalComissoes (List<Comissoes> comissoes);
    }
}
