
using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.Repository.Interface;
using ContabilidadeBeatyBeach.Service.Interface;

namespace ContabilidadeBeatyBeach.Service
{
    public class ResumoMensalService : IResumoMensalService
    {
        private readonly IResumoMensalRepository _resumomensalrepository;

        public ResumoMensalService(IResumoMensalRepository resumomensalrepository)
        {
            _resumomensalrepository = resumomensalrepository;
        }

        public async Task<ResumoMensal?> ObterPorUsuarioEMesAsync(int userId, string mesAno)
        {
            return await _resumomensalrepository.ObterPorUsuarioEMesAsync(userId, mesAno);
        }

        public async Task<ResumoMensal> SalvarOuAtualizarAsync(int userId, string mesAno, decimal totalHoras, decimal totalExtra, decimal salarioTotal)
        {
            
            var existente = await _resumomensalrepository.ObterPorUsuarioEMesAsync(userId, mesAno);

            if (existente != null)
            {
                
                existente.TotalHoras = totalHoras;
                existente.TotalExtra = totalExtra;
                existente.SalarioTotal = salarioTotal;

                
                await _resumomensalrepository.AtualizarAsync(existente);
                return existente;
            }
            else
            {
                var novoResumo = new ResumoMensal
                {
                    UserId = userId,
                    Mes = mesAno,
                    TotalHoras = totalHoras,
                    TotalExtra = totalExtra,
                    SalarioTotal = salarioTotal
                };
               
                await _resumomensalrepository.CriarAsync(novoResumo);
                return novoResumo;
            }
        }
    }
}
