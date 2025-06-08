using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.Domain.Entity.Enum;
using ContabilidadeBeatyBeach.Repository.Interface;
using ContabilidadeBeatyBeach.Service.Interface;

namespace ContabilidadeBeatyBeach.Service
{
    public class HoraExtraService : IHoraExtraService
    {
        private readonly IHoraExtraRepository _horaextrarepository;

        public HoraExtraService(IHoraExtraRepository horaextrarepository)
        {
            _horaextrarepository = horaextrarepository;
        }

        public async Task<HoraExtra> AdicionarHoraExtraAsync(HoraExtra horaExtra)
        {
            return await _horaextrarepository.CriarAsync(horaExtra);
        }


        public async Task<List<HoraExtra>> ObterPorUsuarioEMesAsync(int userId, string data)
        {
            return await _horaextrarepository.ObterPorUsuarioEMesAsync(userId, data);
        }

        public (decimal totalHoras, decimal totalValor) CalcularValores(List<HoraExtra> horaExtras, decimal valorHora)
        {
            decimal totalHoras = 0;
            decimal totalValor = 0;

            foreach (var horaExtra in horaExtras)
            {
                var contamultiplicador = horaExtra.Tipo == TipoDeExtra.Cinquenta ? 1.5m : 2.0m;
                var valor = valorHora * contamultiplicador * horaExtra.QuantidadeHoras;

                totalHoras += horaExtra.QuantidadeHoras;
                totalValor += valor;

                
            }
            return (totalHoras, totalValor);
        }

        
    }
}
