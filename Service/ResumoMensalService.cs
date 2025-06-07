
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

        public async Task<ResumoMensal?> ObterPorUsuarioEMesAsync(int userId, string mes)
        {
            return await _resumomensalrepository.ObterPorUsuarioEMesAsync(userId, mes);
        }

        public async Task<ResumoMensal> SalvarOuAtualizarAsync(int userId, string mes, decimal totalHoras, decimal totalExtra)
        {
            
            var existente = await _resumomensalrepository.ObterPorUsuarioEMesAsync(userId, mes);

            if (existente != null)
            {
                
                existente.TotalHoras = totalHoras;
                existente.TotalExtra = totalExtra;

                
                await _resumomensalrepository.AtualizarAsync(existente);
                return existente;
            }
            else
            {
                var novoResumo = new ResumoMensal
                {
                    UserId = userId,
                    Mes = mes,
                    TotalHoras = totalHoras,
                    TotalExtra = totalExtra
                };
               
                await _resumomensalrepository.CriarAsync(novoResumo);
                return novoResumo;
            }
        }
    }
}
