using Microsoft.AspNetCore.Mvc;
using OrdemServicoAPI.Services.Interfaces;
using OrdemServicoAPI.Models;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
 
    [HttpGet]
    public async Task<IActionResult> GetAllUsuarios()
    {
        var usuarios = await _usuarioService.GetAllUsuariosAsync();
        return Ok(usuarios);
    }
}