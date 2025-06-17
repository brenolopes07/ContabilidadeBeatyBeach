using ContabilidadeBeatyBeach.Domain.Entity;
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

        public async Task<Comissoes> AdicionarComissaoAsync(Comissoes comissoes)
        {
            return await _comissoesrepository.AdicionarComissaoAsync(comissoes);
        }

        public async Task<List<Comissoes>> ObterComissoesPorUsuarioEMesAsync(int userId, string mesAno)
        {
            return await _comissoesrepository.ObterComissoesPorUsuarioEMesAsync(userId, mesAno);
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
