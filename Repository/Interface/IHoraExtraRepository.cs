using ContabilidadeBeatyBeach.Domain.Entity;

namespace ContabilidadeBeatyBeach.Repository.Interface
{
    public interface IHoraExtraRepository
    {
        Task<HoraExtra> ObterPorIdAsync(int id);
        Task<List<HoraExtra>> ObterPorUsuarioAsync(int userId);

        Task<List<HoraExtra>> ObterPorUsuarioEMesAsync(int userId, string mesAno);

        Task <HoraExtra> CriarAsync(HoraExtra horaExtra);

        Task<HoraExtra> AtualizarAsync(HoraExtra horaExtra);

        Task<bool> DeletarAsync(int id);

    }
}
