using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Repositories.Interfaces
{
    public interface IOrdemServicoRepository
    {
        Task<IEnumerable<OrdemServico>> GetAllAsync();
        Task<OrdemServico?> GetByIdAsync(int id);
        Task<OrdemServico> AddAsync(OrdemServico ordemServico);
        Task UpdateAsync(OrdemServico ordemServico);
        Task DeleteAsync(int id);
        Task<IEnumerable<OrdemServico>> GetOrdensServicoByClienteAsync(int clienteId);
        Task<IEnumerable<OrdemServico>> GetOrdensServicoByStatusAsync(StatusEnum status);
    }
}