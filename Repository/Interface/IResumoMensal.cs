using ContabilidadeBeatyBeach.Domain.Entity;

namespace ContabilidadeBeatyBeach.Repository.Interface
{
    public interface IResumoMensal
    {
        Task<ResumoMensal?> ObterPorUsuarioEMesAsync (int usuarioId, string mesAno);

        Task<List<ResumoMensal>> ObterPorUsuarioAsync(int usuarioId);

        Task<ResumoMensal> CriarAsync(ResumoMensal resumoMensal);

        Task<ResumoMensal> AtualizarAsync(ResumoMensal resumoMensal);
    }
}
