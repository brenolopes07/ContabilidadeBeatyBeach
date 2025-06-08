using ContabilidadeBeatyBeach.Domain.Entity;

namespace ContabilidadeBeatyBeach.Service.Interface
{
    public interface IHoraExtraService
    {
        Task<List<HoraExtra>> ObterPorUsuarioEMesAsync(int userId, string data);
        (decimal totalHoras, decimal totalValor) CalcularValores(List<HoraExtra> horasExtras, decimal valorHora);

        Task<HoraExtra> AdicionarHoraExtraAsync(HoraExtra horaExtra);
    }
}
