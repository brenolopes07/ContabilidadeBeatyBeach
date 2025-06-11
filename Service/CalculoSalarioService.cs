using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.Domain.Entity.Enum;
using ContabilidadeBeatyBeach.DTOs.CalculoSalario;
using ContabilidadeBeatyBeach.Service.Interface;

namespace ContabilidadeBeatyBeach.Service
{
    public class CalculoSalarioService : ICalculoSalarioService
    {
        private readonly IUserService _usuarioService;
        private readonly IHoraExtraService _horaExtraService;
        private readonly IResumoMensalService _resumoMensalService;

        public CalculoSalarioService(IUserService usuarioService, IHoraExtraService horaExtraService, IResumoMensalService resumoMensalService)
        {
            _usuarioService = usuarioService;
            _horaExtraService = horaExtraService;
            _resumoMensalService = resumoMensalService;
        }

        public async Task<CalculoSalarioOutputDTO> CalcularSalarioaAsync(int userId, string mesAno)
        {
            var user = await _usuarioService.ObterPorIdAsync(userId);
            if (user == null) return null;

            var valorHora = _usuarioService.CalcularValorHora(user.SalarioMensal);

            var HorasExtras = await _horaExtraService.ObterPorUsuarioEMesAsync(userId, mesAno);

            var (totalHoras, totalValorExtra) = _horaExtraService.CalcularValores(HorasExtras, valorHora);

            var salarioTotal = user.SalarioMensal + totalValorExtra;

            await _resumoMensalService.SalvarOuAtualizarAsync(userId, mesAno, totalHoras, totalValorExtra, salarioTotal);

            return new CalculoSalarioOutputDTO
            {
                Usuario = user.Username,
                Mes = mesAno,
                SalarioBase = user.SalarioMensal,
                ValorHora = valorHora,
                TotalHorasExtras = totalHoras,
                ValorHorasExtras = totalValorExtra,
                SalarioTotal = salarioTotal,
            };
        }

        }
    }

