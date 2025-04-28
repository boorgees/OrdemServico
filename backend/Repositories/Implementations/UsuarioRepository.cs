using Microsoft.EntityFrameworkCore;
using OrdemServicoAPI.Data;
using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await Task.CompletedTask;
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario = await GetUsuarioByIdAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
        }
        
    }
}