using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.DTOs.User;

namespace ContabilidadeBeatyBeach.Service.Interface
{
    public interface IUserService
    {
        Task<Usuarios?> ObterPorIdAsync(int id);
        decimal CalcularValorHora(decimal salarioMensal);
        Task<Usuarios?> ObterPorUsernameAsync(string username);

        Task<Usuarios> ObterOuCriar(CriarOuObterUserInputDTO dto);

        
    }
}
