using System.Collections.Generic;
using System.Threading.Tasks;
using OrdemServicoAPI.Models;


namespace OrdemServicoAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario?> GetUsuarioByIdAsync(int id);
        Task<Usuario?> GetByEmailAsync(string email);
        Task<Usuario> AddUsuarioAsync(Usuario usuario);
        Task<Usuario> UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}