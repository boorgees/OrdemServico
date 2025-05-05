using Microsoft.AspNetCore.Mvc;
using OrdemServicoAPI.Services.Interfaces;
using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Controllers
{
    [ApiController]
    [Route("api/ordens-servico")]
    public class OrdemServicoController : ControllerBase
    {
        private readonly IOrdemServicoService _ordemServicoService;
        private readonly IOrdemServicoServicoService _ordemServicoServicoService;
        private readonly IServicosService _servicosService;

        public OrdemServicoController(
            IOrdemServicoService ordemServicoService,
            IOrdemServicoServicoService ordemServicoServicoService,
            IServicosService servicosService)
        {
            _ordemServicoService = ordemServicoService;
            _ordemServicoServicoService = ordemServicoServicoService;
            _servicosService = servicosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ordensServico = await _ordemServicoService.GetAllOrdensServicoAsync();
                return Ok(ordensServico);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var ordemServico = await _ordemServicoService.GetOrdemServicoByIdAsync(id);
                return Ok(ordemServico);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> GetByCliente(int clienteId)
        {
            try
            {
                var ordensServico = await _ordemServicoService.GetOrdensServicoByClienteAsync(clienteId);
                return Ok(ordensServico);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            try
            {
                var ordensServico = await _ordemServicoService.GetOrdensServicoByStatusAsync(status);
                return Ok(ordensServico);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrdemServico ordemServico)
        {
            try
            {
                var novaOrdemServico = await _ordemServicoService.AddOrdemServicoAsync(ordemServico);
                return CreatedAtAction(nameof(GetById), new { id = novaOrdemServico.Id }, novaOrdemServico);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrdemServico ordemServico)
        {
            try
            {
                if (id != ordemServico.Id)
                {
                    return BadRequest("ID da ordem de serviço não corresponde ao ID fornecido.");
                }

                await _ordemServicoService.UpdateOrdemServicoAsync(ordemServico);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ordemServicoService.DeleteOrdemServicoAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string novoStatus)
        {
            try
            {
                var ordemServico = await _ordemServicoService.UpdateStatusAsync(id, novoStatus);
                return Ok(ordemServico);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost("{ordemServicoId}/servicos/{servicoId}")]
        public async Task<IActionResult> AdicionarServico(int ordemServicoId, int servicoId)
        {
            try
            {
                var ordemServico = await _ordemServicoService.GetOrdemServicoByIdAsync(ordemServicoId);
                if (ordemServico == null)
                {
                    return NotFound("Ordem de serviço não encontrada!");
                }

                var servico = await _servicosService.GetServicoByIdAsync(servicoId);
                if (servico == null)
                {
                    return NotFound("Serviço não encontrado!");
                }

                var ordemServicoServico = new OrdemServicoServico
                {
                    OrdemServicoId = ordemServicoId,
                    ServicoId = servicoId,
                    OrdemServico = ordemServico,
                    Servico = servico
                };

                await _ordemServicoServicoService.AddOrdemServicoServicoAsync(ordemServicoServico);
                return CreatedAtAction(nameof(GetById), new { id = ordemServicoId }, null);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{ordemServicoId}/servicos/{servicoId}")]
        public async Task<IActionResult> RemoverServico(int ordemServicoId, int servicoId)
        {
            try
            {
                await _ordemServicoServicoService.DeleteOrdemServicoServicoAsync(ordemServicoId, servicoId);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
} 