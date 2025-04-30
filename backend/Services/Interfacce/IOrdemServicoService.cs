using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Services.Interfaces
{
    public interface IOrdemServicoService
    {
        Task<IEnumerable<OrdemServico>> GetAllOrdensServicoAsync();
        Task<OrdemServico?> GetOrdemServicoByIdAsync(int id);
        Task<OrdemServico> AddOrdemServicoAsync(OrdemServico ordemServico);
        Task UpdateOrdemServicoAsync(OrdemServico ordemServico);
        Task DeleteOrdemServicoAsync(int id);
    }
}