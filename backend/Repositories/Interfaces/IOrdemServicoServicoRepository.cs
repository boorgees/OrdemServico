using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Repositories.Interfaces
{
    public interface IOrdemServicoServicoRepository
    {
        Task<IEnumerable<OrdemServicoServico>> GetAllAsync();
        Task<OrdemServicoServico?> GetByIdAsync(int ordemServicoId, int servicoId);
        Task<IEnumerable<OrdemServicoServico>> GetByOrdemServicoIdAsync(int ordemServicoId);
        Task<IEnumerable<OrdemServicoServico>> GetByServicoIdAsync(int servicoId);
        Task<OrdemServicoServico> CreateAsync(OrdemServicoServico ordemServicoServico);
        Task<bool> UpdateAsync(OrdemServicoServico ordemServicoServico);
        Task<bool> DeleteAsync(int ordemServicoId, int servicoId);
    }
}