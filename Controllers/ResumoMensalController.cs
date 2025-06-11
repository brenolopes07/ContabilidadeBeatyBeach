using ContabilidadeBeatyBeach.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ContabilidadeBeatyBeach.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResumoMensalController : ControllerBase
    {
        private readonly IResumoMensalService _resumomensalservice;
       
        public ResumoMensalController (IResumoMensalService resumomensalservice)
        {
            _resumomensalservice = resumomensalservice;
        }

        [HttpGet]

        public async Task<ActionResult> ObterResumoMensal(int userId, string mesAno)
        {
            var resumo = await _resumomensalservice.ObterPorUsuarioEMesAsync(userId, mesAno);
            if (resumo == null)
                return NotFound("Nenhum resumo Cadastrado");
            return Ok(resumo);
        }
    }
}
