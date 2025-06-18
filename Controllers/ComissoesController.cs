using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.DTOs.ComissoesDTO;
using ContabilidadeBeatyBeach.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ContabilidadeBeatyBeach.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ComissoesController : ControllerBase
    {
        private readonly IComissoesService _comissoesService;
        private readonly IUserService _userService;

        public ComissoesController(IComissoesService comissoesservice, IUserService userservice)
        {
            _comissoesService = comissoesservice;
            _userService = userservice;
        }

        [HttpPost]
        public async Task<ActionResult<CriarComissaoOutputDTO>> CriarComissao([FromBody] CriarComissaoInputDTO dto)
        {
            var usuario = await _userService.ObterPorIdAsync(dto.UserId);

            if (usuario == null)
                return NotFound("Usuário não encontrado!");

            if (dto.Valor <= 0)
                return BadRequest("Valor da comissão deve ser maior que zero!");

            var comissao = new Comissoes
            {
                Data = dto.Data,
                Valor = dto.Valor,
                Descricao = dto.Descricao,
                UserId = dto.UserId
            };

            var resultado = await _comissoesService.AdicionarComissaoAsync(comissao);

            return Ok(new
            {
                message = "Comissão cadastrada com sucesso!",
                data = resultado
            });
        }
    }
}


