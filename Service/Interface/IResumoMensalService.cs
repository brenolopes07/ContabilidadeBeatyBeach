using ContabilidadeBeatyBeach.Domain.Entity;

namespace ContabilidadeBeatyBeach.Service.Interface
{
    public interface IResumoMensalService
    {
        Task<ResumoMensal?> ObterPorUsuarioEMesAsync(int userId, string mes);
        Task<ResumoMensal> SalvarOuAtualizarAsync(int userId, string mes, decimal totalHoras, decimal totalExtra);
    }
}
