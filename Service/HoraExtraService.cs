using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.Domain.Entity.Enum;
using ContabilidadeBeatyBeach.DTOs.HoraExtra;
using ContabilidadeBeatyBeach.Repository.Interface;
using ContabilidadeBeatyBeach.Service.Interface;

namespace ContabilidadeBeatyBeach.Service
{
    public class HoraExtraService : IHoraExtraService
    {
        private readonly IHoraExtraRepository _horaextrarepository;

        public HoraExtraService(IHoraExtraRepository horaextrarepository)
        {
            _horaextrarepository = horaextrarepository;
        }

        public async Task<CriarHoraExtraOutputDTO> AdicionarHoraExtraAsync(HoraExtra horaExtra)
        {

            var novaHoraExtra = await _horaextrarepository.CriarAsync(horaExtra);

            return new CriarHoraExtraOutputDTO
            {
                Id = novaHoraExtra.Id,
                Data = novaHoraExtra.Data,
                QuantidadeHoras = novaHoraExtra.QuantidadeHoras,
                Tipo = novaHoraExtra.Tipo,
                UserId = novaHoraExtra.UserId,
                User = new UserSimplificadoDto
                {
                    Id = novaHoraExtra.User.Id,
                    Username = novaHoraExtra.User.Username,
                    SalarioMensal = novaHoraExtra.User.SalarioMensal,
                    DataCadastro = novaHoraExtra.User.DataCadastro
                }
            };

        }


        public async Task<List<HoraExtra>> ObterPorUsuarioEMesAsync(int userId, string mesAno)
        {
            return await _horaextrarepository.ObterPorUsuarioEMesAsync(userId, mesAno);
        }

        public (decimal totalHoras, decimal totalValor) CalcularValores(List<HoraExtra> horaExtras, decimal valorHora)
        {
            decimal totalHoras = 0;
            decimal totalValor = 0;

            foreach (var horaExtra in horaExtras)
            {
                var contamultiplicador = horaExtra.Tipo == TipoDeExtra.Cinquenta ? 1.5m : 2.0m;
                var valor = valorHora * contamultiplicador * horaExtra.QuantidadeHoras;

                totalHoras += horaExtra.QuantidadeHoras;
                totalValor += valor;

                
            }
            return (totalHoras, totalValor);
        }
        public async Task<DeletarHoraExtraDTO> DeletarHoraExtra(int id)
        {
            var horaExtraExistente = await _horaextrarepository.ObterPorIdAsync(id);

            if (horaExtraExistente == null)
            {
                throw new Exception("Esse registro de hora extra nao existe!");
            }

            await _horaextrarepository.DeletarAsync(id);

            return new DeletarHoraExtraDTO
            {
                Message = "Registro de hora extra deletado com sucesso!",
                HoraExtraDeletada = horaExtraExistente
            };

        }

        
    }
}
