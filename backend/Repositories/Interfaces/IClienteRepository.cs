using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetClienteByIdAsync(int id);
        Task<Cliente?> GetByEmailAsync(string email);
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task AddClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
    }
}