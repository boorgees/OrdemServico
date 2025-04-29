using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetClienteByIdAsync(int id);
        Task<Cliente?> GetByEmailAsync(string email);
        Task<Cliente?> GetClienteByCpfAsync(string cpf);
        Task<Cliente?> GetClienteByTelefone(string telefone);
        Task<Cliente?> GetClienteByNome(string nome);
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task AddClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
    }
}