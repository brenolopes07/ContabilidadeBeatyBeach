using ContabilidadeBeatyBeach.Domain.Entity;

namespace ContabilidadeBeatyBeach.Service.Interface
{
    public interface IResumoMensalService
    {
        Task<ResumoMensal?> ObterPorUsuarioEMesAsync(int userId, string mesAno);
        Task<ResumoMensal> SalvarOuAtualizarAsync(int userId, string mesAno, decimal totalHoras, decimal totalExtra, decimal salarioTotal);
    }
}
