using OrdemServicoAPI.Models;
using OrdemServicoAPI.Repositories.Interfaces;
using OrdemServicoAPI.Services.Interfaces;

namespace OrdemServicoAPI.Services.Implementations
{
    public class OrdemServicoServicoService : IOrdemServicoServicoService
    {
        private readonly IOrdemServicoServicoRepository _ordemServicoServicoRepository;
        private readonly IOrdemServicoRepository _ordemServicoRepository;

        public OrdemServicoServicoService(IOrdemServicoServicoRepository ordemServicoServicoRepository, IOrdemServicoRepository ordemServicoRepository)
        {
            _ordemServicoServicoRepository = ordemServicoServicoRepository;
            _ordemServicoRepository = ordemServicoRepository;
        }

        public async Task<IEnumerable<OrdemServico>> GetAllAsync()
        {
            var ordensServico = await _ordemServicoServicoRepository.GetAllAsync();
            if (ordensServico == null || !ordensServico.Any())
            {
                throw new KeyNotFoundException("Nenhuma ordem de serviço encontrada!");
            }
            return ordensServico.Select(os => os.OrdemServico).ToList();
        }


        public async Task<OrdemServico> AddAsync(OrdemServico ordemServico)
        {
            var ordemServicoServico = await _ordemServicoServicoRepository.GetByOrdemServicoIdAsync(ordemServico.Id);
            if (ordemServicoServico != null && ordemServicoServico.Any())
            {
                throw new InvalidOperationException("Ordem de serviço já existe!");
            }
            return await _ordemServicoRepository.AddAsync(ordemServico);
        }

        public async Task UpdateAsync(OrdemServico ordem)
        {

            var ordemServicoExistente = await _ordemServicoServicoRepository.GetByIdAsync(ordem.Id, ordem.Servicos.FirstOrDefault()?.ServicoId ?? 0);
            if (ordemServicoExistente == null)
            {
                throw new KeyNotFoundException("Ordem de serviço não encontrada para atualização!");
            }

            await _ordemServicoRepository.UpdateAsync(ordem);
        }

        public async Task DeleteAsync(int id)
        {
            var ordemServico = await _ordemServicoServicoRepository.GetByIdAsync(id, id);
            if (ordemServico == null)
            {
                throw new KeyNotFoundException("Ordem de serviço não encontrada!");
            }
            await _ordemServicoRepository.DeleteAsync(id);
        }

        public async Task<OrdemServico?> GetByIdAsync(int ordemServicoId, int servicoId)
        {
            var ordemServico = await _ordemServicoServicoRepository.GetByIdAsync(ordemServicoId, servicoId);
            if (ordemServico == null)
            {
                throw new KeyNotFoundException("Ordem de serviço não encontrada!");
            }
            return ordemServico.OrdemServico;

        }

        public async Task<OrdemServicoServico> AddOrdemServicoServicoAsync(OrdemServicoServico ordemServicoServico)
        {
            return await _ordemServicoServicoRepository.AddAsync(ordemServicoServico);
        }

        public async Task DeleteOrdemServicoServicoAsync(int ordemServicoId, int servicoId)
        {
            await _ordemServicoServicoRepository.DeleteAsync(ordemServicoId, servicoId);
        }

        public async Task<IEnumerable<OrdemServicoServico>> GetOrdemServicoServicosByOrdemServicoIdAsync(int ordemServicoId)
        {
            return await _ordemServicoServicoRepository.GetByOrdemServicoIdAsync(ordemServicoId);
        }

        public async Task<IEnumerable<OrdemServicoServico>> GetOrdemServicoServicosByServicoIdAsync(int servicoId)
        {
            return await _ordemServicoServicoRepository.GetByServicoIdAsync(servicoId);
        }
    }
}