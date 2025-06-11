using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.DTOs.CalculoSalario;

namespace ContabilidadeBeatyBeach.Service.Interface
{
    public interface ICalculoSalarioService
    {
        Task<CalculoSalarioOutputDTO> CalcularSalarioaAsync(int userId, string mes);

    }
}
