using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Services.Interfaces
{
    public interface IOrdemServicoService
    {
        Task<IEnumerable<OrdemServico>> GetAllOrdensServicoAsync();
        Task<OrdemServico?> GetOrdemServicoByIdAsync(int id);
        Task<IEnumerable<OrdemServico>> GetOrdensServicoByClienteAsync(int clienteId);
        Task<IEnumerable<OrdemServico>> GetOrdensServicoByStatusAsync(string status);
        Task<OrdemServico> AddOrdemServicoAsync(OrdemServico ordemServico);
        Task UpdateOrdemServicoAsync(OrdemServico ordemServico);
        Task DeleteOrdemServicoAsync(int id);
        Task<OrdemServico> UpdateStatusAsync(int id, string novoStatus);
    }
}