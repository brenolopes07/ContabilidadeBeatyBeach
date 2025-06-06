using ContabilidadeBeatyBeach.Domain.Entity;

namespace ContabilidadeBeatyBeach.Repository.Interface
{
    public interface IUserRepository
    {
        Task<Usuarios> ObterPorIdAsync(int id);

        Task<Usuarios> ObterPorUsernameAsync(string username);

        Task<List<Usuarios>> ObterTodosAsync();

        Task<Usuarios> AdicionarAsync(Usuarios user);

        Task<Usuarios> AtualizarAsync(Usuarios user);

        Task<bool> DeletarAsync(int id);


    }
}
