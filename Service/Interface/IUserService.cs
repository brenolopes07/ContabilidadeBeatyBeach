using ContabilidadeBeatyBeach.Domain.DTOs.User;
using ContabilidadeBeatyBeach.Domain.Entity;

namespace ContabilidadeBeatyBeach.Service.Interface
{
    public interface IUserService
    {
        Task<Usuarios?> ObterPorIdAsync(int id);
        decimal CalcularValorHora(decimal salarioMensal);

        Task<Usuarios> ObterOuCriar(CriarOuObterUserInputDTO dto);

        
    }
}
