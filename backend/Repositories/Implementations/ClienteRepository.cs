using OrdemServicoAPI.Data;
using OrdemServicoAPI.Models;
using OrdemServicoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Repositories.Implementations
{

    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return clientes;
        }

        public async Task<Cliente?> GetByEmailAsync(string email)
        {
            var clienteEmail = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);
            return clienteEmail;

        }

        public async Task<Cliente?> GetClienteByIdAsync(int id)
        {
            var clienteId = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            return clienteId;
        }

        public async Task<Cliente?> GetClienteByCpfAsync(string cpf)
        {
            var clienteCpf = await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
            return clienteCpf;
        }

        public async Task<Cliente?> GetClienteByTelefone(string telefone)
        {
            var clienteTelefone = await _context.Clientes.FirstOrDefaultAsync(c => c.Telefone == telefone);
            return clienteTelefone;
        }

        public async Task<Cliente?> GetClienteByNome(string nome)
        {
            var clienteNome = await _context.Clientes.FirstOrDefaultAsync(c => c.Nome == nome);
            return clienteNome;
        }
        public async Task AddClienteAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public Task UpdateClienteAsync(Cliente cliente)
        {
            var clienteUpdate = _context.Clientes.Update(cliente);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

    }

}