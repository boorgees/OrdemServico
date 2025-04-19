using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Repositories.Interfaces
{
    public interface IOrdemServicoRepository
    {
        Task<IEnumerable<OrdemServico>> GetAllAsync();
        Task<OrdemServico?> GetByIdAsync(int id);
        Task AddAsync(OrdemServico ordem);
        Task UpdateAsync(OrdemServico ordem);
        Task DeleteAsync(int id);
    }
}