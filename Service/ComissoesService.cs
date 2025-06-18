using ContabilidadeBeatyBeach.Domain.Entity;
using ContabilidadeBeatyBeach.DTOs.ComissoesDTO;
using ContabilidadeBeatyBeach.Repository.Interface;
using ContabilidadeBeatyBeach.Service.Interface;

namespace ContabilidadeBeatyBeach.Service
{
    public class ComissoesService : IComissoesService   
    {
        private readonly IComissoesRepository _comissoesrepository;
        public ComissoesService(IComissoesRepository comissoesrepository)
        {
            _comissoesrepository = comissoesrepository;
        }

        public async Task<CriarComissaoOutputDTO> AdicionarComissaoAsync(Comissoes comissoes)
        {
            var novaComissao = await _comissoesrepository.AdicionarComissaoAsync(comissoes);

            return new CriarComissaoOutputDTO
            {
                Id = novaComissao.Id,
                Data = novaComissao.Data,
                Valor = novaComissao.Valor,
                UserId = novaComissao.UserId,
                User = new UserSimplificadoComissoesDto
                {
                    Id = novaComissao.Usuario.Id,
                    Username = novaComissao.Usuario.Username,
                    SalarioMensal = novaComissao.Usuario.SalarioMensal,
                    DataCadastro = novaComissao.Usuario.DataCadastro
                },

            };
        }

        public async Task<List<Comissoes>> ObterComissoesPorUsuarioEMesAsync(int userId, string mesAno)
        {
            return await _comissoesrepository.ObterComissoesPorUsuarioEMesAsync(userId, mesAno);
        }

        public decimal CalcularTotalComissoes(List<Comissoes> comissoes)
        {
            decimal totalValorComissao = 0;
            foreach (var comissao in comissoes)
            {
                totalValorComissao += comissao.Valor;
            }

            return (totalValorComissao);
        }

        public async Task<Comissoes> DeletarComissaoAsync(int id)
        {
            var comissao = await _comissoesrepository.ObterPorIdAsync(id);
            if(comissao == null)
            {
                throw new Exception("Comissão não encontrada.");
            }

            await _comissoesrepository.DeletarComissaoAsync(id);

            return comissao;
        }
    }
}
