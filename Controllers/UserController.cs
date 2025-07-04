using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.DTOs.ComissoesDTO;
using ContabilidadeBeatyBeach.DTOs.HoraExtra;
using ContabilidadeBeatyBeach.DTOs.ResumoMensalDTO;
using ContabilidadeBeatyBeach.DTOs.User;
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
        public async Task<ActionResult<Usuarios>> CriarUsuario([FromBody] CriarOuObterUserInputDTO dto)
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
        public async Task<ActionResult> ObterUsuarioPorId(int id)
        {
            var usuario = await _userService.ObterPorIdAsync(id);
            if (usuario == null)
                return NotFound("Usuario nao encontrado!");


            var dto = new GetUsuarioOutputDTO
            {
                Id = usuario.Id,
                Username = usuario.Username,
                SalarioMensal = usuario.SalarioMensal,
                HoraExtras = usuario.HoraExtras?.Select(h => new HoraExtraOutputDTO
                {
                    Id = h.Id,
                    Data = h.Data,
                    QuantidadeHoras = h.QuantidadeHoras,
                }).ToList(),
                Comissoes = usuario.Comissoes?.Select(c => new GetComissoesOutputDTO
                {
                    Id = c.Id,
                    Data = c.Data,
                    Valor = c.Valor,
                    Descricao = c.Descricao
                }).ToList(),
                ResumoMensal = usuario.ResumoMensal?.Select(r => new GetResumoMensalDTO
                {
                    Id = r.Id,
                    mesAno = r.Mes, 
                    TotalHoras = r.TotalHoras,
                    TotalExtra = r.TotalExtra,
                    TotalComissoes = r.TotalComissoes,
                    SalarioTotal = r.SalarioTotal

                }).ToList()
            };

            return Ok(dto);

        }
        [HttpGet]
        public async Task<ActionResult> ObterUsuarioPorUsername([FromQuery] string username)
        {
            var usuario = await _userService.ObterPorUsernameAsync(username);
            if(usuario == null)
                return NotFound("Usuario nao encontrado!");

            var dto = new GetUsuarioOutputDTO
            {
                Id = usuario.Id,
                Username = usuario.Username,
                SalarioMensal = usuario.SalarioMensal,
                HoraExtras = usuario.HoraExtras?.Select(h => new HoraExtraOutputDTO
                {
                    Id = h.Id,
                    Data = h.Data,
                    QuantidadeHoras = h.QuantidadeHoras,
                }).ToList(),
                Comissoes = usuario.Comissoes?.Select(c => new GetComissoesOutputDTO
                {
                    Id = c.Id,
                    Data = c.Data,
                    Valor = c.Valor,
                    Descricao = c.Descricao
                }).ToList(),
                ResumoMensal = usuario.ResumoMensal?.Select(r => new GetResumoMensalDTO
                {
                    Id = r.Id,
                    mesAno = r.Mes,
                    TotalHoras = r.TotalHoras,
                    TotalExtra = r.TotalExtra,
                    TotalComissoes = r.TotalComissoes,
                    SalarioTotal = r.SalarioTotal
                }).ToList()
            };

            return Ok(dto);
        }

    }
}
