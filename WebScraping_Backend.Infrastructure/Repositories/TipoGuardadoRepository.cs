using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraping_Backend.Core.Entities;
using WebScraping_Backend.Core.Interfaces;
using WebScraping_Backend.Infrastructure.Data;

namespace WebScraping_Backend.Infrastructure.Repositories
{
    public class TipoGuardadoRepository : ITipoGuardadoRepository
    {
        private readonly ProjectWebScrapingContext _webScrapingContext;

        public TipoGuardadoRepository(ProjectWebScrapingContext projectWebScrapingContext)
        {
            _webScrapingContext = projectWebScrapingContext;
        }

        public async Task<IEnumerable<TipoGuardado>> GetAll()
        {
            return await _webScrapingContext.TipoGuardado.ToListAsync();
        }

        public async Task<TipoGuardado> GetById(int id)
        {
            return await _webScrapingContext.TipoGuardado.Where(x => x.IdTipoGuardado == id).FirstOrDefaultAsync();

        }

        public async Task<bool> Insert(TipoGuardado tipoGuardado)
        {
            await _webScrapingContext.TipoGuardado.AddAsync(tipoGuardado);
            int rows = await _webScrapingContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(TipoGuardado tipoGuardado)
        {
            _webScrapingContext.TipoGuardado.Update(tipoGuardado);
            int rows = await _webScrapingContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var TipoGuardado = await _webScrapingContext.TipoGuardado.FindAsync(id);
            if (TipoGuardado != null)
            {
                _webScrapingContext.TipoGuardado.Remove(TipoGuardado);
                int rows = await _webScrapingContext.SaveChangesAsync();
                return rows > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
