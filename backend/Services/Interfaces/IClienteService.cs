using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task<Cliente?> GetClienteByIdAsync(int id);
        Task<Cliente?> GetClienteByEmailAsync(string email);
        Task<Cliente?> GetClienteByCpfAsync(string cpf);
        Task<Cliente?> GetClienteByTelefone(string telefone);
        Task<Cliente?> GetClienteByNome(string nome);
        Task<Cliente> AddClienteAsync(Cliente cliente);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
    }
}