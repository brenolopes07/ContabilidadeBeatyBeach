using ContabilidadeBeatyBeach.Domain.DTOs;
using ContabilidadeBeatyBeach.Domain.Entity;

namespace ContabilidadeBeatyBeach.Service.Interface
{
    public interface ICalculoSalarioService
    {
        Task<CalculoSalarioDTO> CalcularSalarioaAsync(int userId, string mes);
        Task<ResumoMensal> SalvarResumoAsync(int userId, string mes);
    }
}
