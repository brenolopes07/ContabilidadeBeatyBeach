using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.DTOs.HoraExtra;

namespace ContabilidadeBeatyBeach.Service.Interface
{
    public interface IHoraExtraService
    {
        Task<List<HoraExtra>> ObterPorUsuarioEMesAsync(int userId, string mesAno);
        (decimal totalHoras, decimal totalValor) CalcularValores(List<HoraExtra> horasExtras, decimal valorHora);

        Task<CriarHoraExtraOutputDTO> AdicionarHoraExtraAsync(HoraExtra horaExtra);
    }
}
