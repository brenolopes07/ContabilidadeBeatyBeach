using ContabilidadeBeatyBeach.DTOs.CalculoSalario;
using ContabilidadeBeatyBeach.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ContabilidadeBeatyBeach.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculoSalarioController : ControllerBase
    {
        private readonly ICalculoSalarioService _calculoSalarioService;

        public CalculoSalarioController(ICalculoSalarioService calculoSalarioService)
        {
            _calculoSalarioService = calculoSalarioService;
        }

        [HttpPost]
        public async Task<ActionResult<CalculoSalarioOutputDTO>> CalcularSalario([FromBody] CalculoSalarioInputDTO dto)
        {
            if (dto.UserId <= 0 || string.IsNullOrWhiteSpace(dto.MesAno))
                return BadRequest("Dados invalidos!");
            var resultado = await _calculoSalarioService.CalcularSalarioaAsync(dto.UserId, dto.MesAno);
            if (resultado == null)
                return NotFound("Usuario ou mes nao encontrado!");
            return Ok(resultado);
        }

    }
}
