using Microsoft.AspNetCore.Mvc;
using OrdemServicoAPI.Services.Interfaces;

namespace OrdemServicoAPI.Controllers
{
    [ApiController]
    [Route("api/servicos")]

    public class ServicosController : ControllerBase
    {
        private readonly IServicosService _servicosService;

        public ServicosController(IServicosService servicosService)
        {
            _servicosService = servicosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServicos()
        {
            try
            {
                var servicos = await _servicosService.GetAllServicosAsync();
                return Ok(servicos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicoById(int id)
        {
            try
            {
                var servico = await _servicosService.GetServicoByIdAsync(id);
                if (servico == null)
                {
                    return NotFound($"Serviço com o ID {id} não encontrado.");
                }
                return Ok(servico);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("name/{nome}")]
        public async Task<IActionResult> GetServicoByName(string nome)
        {
            try
            {
                var servico = await _servicosService.GetServicoByNameAsync(nome);
                if (servico == null)
                {
                    return NotFound($"Serviço com nome {nome} não encontrado.");
                }
                return Ok(servico);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddServico([FromBody] Servico servico)
        {
            if (servico == null)
            {
                return BadRequest("Serviço não pode ser nulo.");
            }

            try
            {
                var createdServico = await _servicosService.AddServicoAsync(servico);
                return CreatedAtAction(nameof(GetServicoById), new { id = createdServico.Id }, createdServico);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServico(int id, [FromBody] Servico servico)
        {
            if (servico == null || servico.Id != id)
            {
                return BadRequest("Serviço inválido ou ID não corresponde.");
            }

            try
            {
                var existingServico = await _servicosService.GetServicoByIdAsync(id);
                if (existingServico == null)
                {
                    return NotFound($"Serviço com o ID {id} não encontrado.");
                }

                await _servicosService.UpdateServicoAsync(servico);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServico(int id)
        {
            try
            {
                var existingServico = await _servicosService.GetServicoByIdAsync(id);
                if (existingServico == null)
                {
                    return NotFound($"Serviço com o ID {id} não encontrado.");
                }

                await _servicosService.DeleteServicoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}