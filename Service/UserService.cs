using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.Repository.Interface;
using ContabilidadeBeatyBeach.Service.Interface;

namespace ContabilidadeBeatyBeach.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Usuarios?> ObterPorIdAsync(int id)
        {
            return await _userRepository.ObterPorIdAsync(id);
        }

        public decimal CalcularValorHora(decimal salarioMensal)
        {
            return salarioMensal / 30 / 8;
        }
    }
}
