using ContabilidadeBeatyBeach.Domain.DTOs;
using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ContabilidadeBeatyBeach.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<Usuarios>> CriarUsuario([FromBody] CriarOuObterUserDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username) || dto.SalarioMensal <= 0)
                return BadRequest("Dados Invalidos!");

            var usuario = await _userService.ObterOuCriar(dto);
            var valorHora = _userService.CalcularValorHora(usuario.SalarioMensal);

            return Ok(new
            {
                Mensagem = "Usuario criado com sucesso!",
                Usuario = usuario,
                ValorHora = valorHora
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> ObterUsuarioPorId(int id)
        {
            var usuario = await _userService.ObterPorIdAsync(id);
            if (usuario == null)
                return NotFound("Usuario nao encontrado!");
            return Ok(usuario);
        }

    }
}
