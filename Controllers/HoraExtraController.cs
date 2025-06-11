using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.DTOs.HoraExtra;
using ContabilidadeBeatyBeach.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ContabilidadeBeatyBeach.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoraExtraController : ControllerBase
    {
        private readonly IHoraExtraService _horaExtraService;
        private readonly IUserService _userService;

        public HoraExtraController(IHoraExtraService horaExtraService, IUserService userService)
        {
            _userService = userService;
            _horaExtraService = horaExtraService;
        }

        [HttpPost]
        public async Task<ActionResult<CriarHoraExtraOutputDTO>> CriarHoraExtra([FromBody] CriarHoraExtraInputDTO dto)
        {
            var usuario = await _userService.ObterPorIdAsync(dto.UserId);
            if (usuario == null)
                return NotFound("Usuario nao encontrado!");

            if (dto.QuantidadeHoras <= 0)
                return BadRequest("Quantidade de horas deve ser maior que zero!");

            var horaExtra = new HoraExtra
            {
                Data = dto.Data,
                QuantidadeHoras = dto.QuantidadeHoras,
                Tipo = dto.Tipo,
                UserId = dto.UserId
            };

            var resultado = await _horaExtraService.AdicionarHoraExtraAsync(horaExtra);

            return Ok(new
            {
                message = "Hora Extra cadastrada com sucesso!",
                data = resultado
            } );
        }
    }
}
