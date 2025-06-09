using ContabilidadeBeatyBeach.Domain.DTOs.CalculoSalario;
using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.Domain.Entity.Enum;
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

        public async Task<CalculoSalarioDTO> CalcularSalarioaAsync(int userId, string mes)
        {
            var user = await _usuarioService.ObterPorIdAsync(userId);
            if (user == null) return null;

            var valorHora = _usuarioService.CalcularValorHora(user.SalarioMensal);

            var HorasExtras = await _horaExtraService.ObterPorUsuarioEMesAsync(userId, mes);

            var (totalHoras, totalValorExtra) = _horaExtraService.CalcularValores(HorasExtras, valorHora);

            var salarioTotal = user.SalarioMensal + totalValorExtra;

            var horasExtrasDetalhadas = HorasExtras.Select(h => new HoraExtraDetalhadaDTO
            {
                Data = h.Data.ToString("dd/MM/yyyy"),
                Tipo = h.Tipo.ToString(""),
                QuantidadeHoras = h.QuantidadeHoras,
                ValorHoraExtra = valorHora,
                ValorCaculado = h.QuantidadeHoras * valorHora
            }).ToList();

            return new CalculoSalarioDTO
            {
                Usuario = user.Username,
                Mes = mes,
                SalarioBase = user.SalarioMensal,
                ValorHora = valorHora,
                TotalHorasExtras = totalHoras,
                ValorHorasExtras = totalValorExtra,
                SalarioTotal = salarioTotal,
            };
        }

        public async Task<ResumoMensal> SalvarResumoAsync(int userId, string mes)
        {
            var usuario = await _usuarioService.ObterPorIdAsync(userId);
            if (usuario == null) return null;

            var valorHora = _usuarioService.CalcularValorHora(usuario.SalarioMensal);
            var horasExtras = await _horaExtraService.ObterPorUsuarioEMesAsync(userId, mes);
            var (totalHoras, totalExtra) = _horaExtraService.CalcularValores(horasExtras, valorHora);

            return await _resumoMensalService.SalvarOuAtualizarAsync(userId, mes, totalHoras, totalExtra);
        }
    }
}
