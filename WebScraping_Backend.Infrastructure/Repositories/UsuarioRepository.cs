using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraping_Backend.Core.Entities;
using WebScraping_Backend.Infrastructure.Data;

namespace WebScraping_Backend.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ProjectWebScrapingContext _context;
        public UsuarioRepository(ProjectWebScrapingContext projectWebScrapingContext)
        {
            _context = projectWebScrapingContext;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var search = await _context.Usuario
                .OrderByDescending(u => u.Apellidos)
                .ToListAsync();
            return (search.Any()) ? search : Enumerable.Empty<Usuario>();
        }

        public async Task<Usuario?> GetById(int id)
        {
            var search = await _context.Usuario.FindAsync(id);
            return (search != null) ? search : null;
        }

        public async Task<bool> Insert(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            int rows = await _context.Usuario.CountAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Usuario usuario)
        {
            _context.Update(usuario);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var search = await _context.Usuario.FindAsync(id);
            if (search != null)
            {
                _context.Usuario.Remove(search);
                int rows = await _context.SaveChangesAsync();
                return rows > 0;
            }
            else
            {
                return false;
            }
        }

        public async Task<Usuario?> SignIn(string email, string contraseña)
        {
            var user = await _context
                .Usuario
                .Where(x => x.Email == email && x.Password == contraseña && x.Estado == true).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<bool> SignUp(Usuario user)
        {
            await _context.Usuario.AddAsync(user);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> IsEmailRegistered(string email)
        {
            return await _context.Usuario.Where(x => x.Email == email).AnyAsync();
        }
        public async Task<bool> UpdateUltimoAcceso(int idUsuario, DateTime ultimoAcceso)
        {
            var usuario = await GetById(idUsuario);
            if (usuario == null)
            {
                return false;
            }
            usuario.UltimoAcceso = ultimoAcceso;
            return await Update(usuario);
        }

    }
}
