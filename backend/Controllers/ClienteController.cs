using Microsoft.AspNetCore.Mvc;
using OrdemServicoAPI.Services.Interfaces;

namespace OrdemServicoAPI.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            return Ok(cliente);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetClienteByEmail(string email)
        {
            var cliente = await _clienteService.GetClienteByEmailAsync(email);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            return Ok(cliente);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetClienteByCpf(string cpf)
        {
            var cliente = await _clienteService.GetClienteByCpfAsync(cpf);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente(Models.Cliente cliente)
        {
            var createdCliente = await _clienteService.AddClienteAsync(cliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = createdCliente.Id }, createdCliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, Models.Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest("ID do cliente não corresponde ao ID fornecido.");
            }

            var updatedCliente = await _clienteService.UpdateClienteAsync(cliente);
            if (updatedCliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            return Ok(updatedCliente);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }

            await _clienteService.DeleteClienteAsync(id);
            return NoContent();
        }
        [HttpGet("telefone/{telefone}")]
        public async Task<IActionResult> GetClienteByTelefone(string telefone)
        {
            var cliente = await _clienteService.GetClienteByTelefone(telefone);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            return Ok(cliente);
        }
        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetClienteByNome(string nome)
        {
            var cliente = await _clienteService.GetClienteByNome(nome);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            return Ok(cliente);
        }
        
    }
}