using OrdemServicoAPI.Models;
using OrdemServicoAPI.Services.Interfaces;
using OrdemServicoAPI.Repositories.Interfaces;
using Npgsql.Replication.PgOutput.Messages;

namespace OrdemServicoAPI.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<Cliente> AddClienteAsync(Cliente cliente)
        {
            var clienteEmail = await _clienteRepository.GetByEmailAsync(cliente.Email);
            var clienteCpf = await _clienteRepository.GetClienteByCpfAsync(cliente.Cpf);
            if (clienteCpf != null || clienteEmail != null)
            {
                throw new Exception("Cliente já existe!");
            }

            await _clienteRepository.AddClienteAsync(cliente);
            return cliente;
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado!");
            }
            await _clienteRepository.DeleteClienteAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            var clientes = await _clienteRepository.GetAllClientesAsync();
            if (clientes == null)
            {
                throw new Exception("Nenhum cliente encontrado!");
            }
            return clientes;
        }

        public async Task<Cliente?> GetClienteByEmailAsync(string email)
        {
            try
            {
                var cliente = await _clienteRepository.GetByEmailAsync(email);
                if (cliente == null)
                {
                    throw new Exception("Cliente não encontrado!");
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar cliente: {ex.Message}");
            }
        }

        public async Task<Cliente?> GetClienteByIdAsync(int id)
        {
            var clienteId = await _clienteRepository.GetClienteByIdAsync(id);
            if (clienteId == null)
            {
                throw new Exception("Cliente não encontrado!");
            }
            return clienteId;
        }

        public async Task<Cliente?> GetClienteByCpfAsync(string cpf)
        {
            var clienteCpf = await _clienteRepository.GetClienteByCpfAsync(cpf);
            if (clienteCpf == null)
            {
                throw new Exception("Cliente não encontrado!");
            }
            return clienteCpf;
        }

        public Task<Cliente?> GetClienteByTelefone(string telefone)
        {
            var clienteTelefone = _clienteRepository.GetClienteByTelefone(telefone);
            if (clienteTelefone == null)
            {
                throw new Exception("Cliente não encontrado!");
            }
            return clienteTelefone;
        }

        public async Task<Cliente?> GetClienteByNome(string nome)
        {
            var clienteNome = await _clienteRepository.GetClienteByNome(nome);
            if (clienteNome == null)
            {
                throw new Exception("Cliente não encontrado!");
            }
            return clienteNome;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var clienteExistente = await _clienteRepository.GetClienteByIdAsync(cliente.Id);
            if (clienteExistente == null)
            {
                throw new Exception("Cliente não encontrado para atualização.");
            }

            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Telefone = cliente.Telefone;
            clienteExistente.Cpf = cliente.Cpf;
            clienteExistente.Endereco = cliente.Endereco;
            clienteExistente.Status = cliente.Status;
            
            await _clienteRepository.UpdateClienteAsync(clienteExistente);

            return clienteExistente;
        }

    }
}