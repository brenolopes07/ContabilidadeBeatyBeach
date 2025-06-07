using ContabilidadeBeatyBeach.Domain.Entity;

namespace ContabilidadeBeatyBeach.Repository.Interface
{
    public interface IResumoMensalRepository
    {
        Task<ResumoMensal?> ObterPorUsuarioEMesAsync (int UserId, string mesAno);

        Task<List<ResumoMensal>> ObterPorUsuarioAsync(int UserId);

        Task<ResumoMensal> CriarAsync(ResumoMensal resumoMensal);

        Task<ResumoMensal> AtualizarAsync(ResumoMensal resumoMensal);
    }
}
