namespace OrdemServicoAPI.Services.Interfaces
{
    using OrdemServicoAPI.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrdemServicoServicoService
    {
        Task<IEnumerable<OrdemServico>> GetAllAsync();
        Task<OrdemServico?> GetByIdAsync(int ordemServicoId, int ServicoId);
        Task<OrdemServico> AddAsync(OrdemServico ordemServico);
        Task UpdateAsync(OrdemServico ordem);
        Task DeleteAsync(int id);
        Task<OrdemServicoServico> AddOrdemServicoServicoAsync(OrdemServicoServico ordemServicoServico);
        Task DeleteOrdemServicoServicoAsync(int ordemServicoId, int servicoId);
        Task<IEnumerable<OrdemServicoServico>> GetOrdemServicoServicosByOrdemServicoIdAsync(int ordemServicoId);
        Task<IEnumerable<OrdemServicoServico>> GetOrdemServicoServicosByServicoIdAsync(int servicoId);
    }
}