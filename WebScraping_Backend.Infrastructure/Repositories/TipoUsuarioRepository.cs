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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly ProjectWebScrapingContext _context;

        public TipoUsuarioRepository(ProjectWebScrapingContext projectWebScrapingContext)
        {
            _context = projectWebScrapingContext;
        }
        public async Task<IEnumerable<TipoUsuario>> GetAll()
        {
            return await _context.TipoUsuario.ToListAsync();
        }

        public async Task<TipoUsuario> GetById(int id)
        {
            return await _context.TipoUsuario.Where(x => x.IdTipoUsuario == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(TipoUsuario tipoUsuario)
        {
            await _context.TipoUsuario.AddAsync(tipoUsuario);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(TipoUsuario tipoUsuario)
        {
            _context.TipoUsuario.Update(tipoUsuario);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var tipoUsuario = await _context.TipoUsuario.FindAsync(id);
            if (tipoUsuario != null)
            {
                _context.TipoUsuario.Remove(tipoUsuario);
                int rows = await _context.SaveChangesAsync();
                return rows > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
