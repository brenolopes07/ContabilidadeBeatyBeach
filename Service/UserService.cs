using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.DTOs.User;
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

        public async Task<Usuarios> ObterOuCriar(CriarOuObterUserInputDTO dto)
        {
            var user = await _userRepository.ObterPorUsernameAsync(dto.Username);
            if (user != null)
                return user;

            var novoUsuario = new Usuarios
            {
                Username = dto.Username,
                SalarioMensal = dto.SalarioMensal
            };

            return await _userRepository.AdicionarAsync(novoUsuario);
        }

        public decimal CalcularValorHora(decimal salarioMensal)
        {
            return salarioMensal / 30 / 8;
        }
    }
}
