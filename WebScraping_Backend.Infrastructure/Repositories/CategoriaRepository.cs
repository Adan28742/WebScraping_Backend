using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraping_Backend.Infrastructure.Data;
using WebScraping_Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using WebScraping_Backend.Core.Interfaces;

namespace WebScraping_Backend.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ProjectWebScrapingContext _webScrapingContext;

        public CategoriaRepository(ProjectWebScrapingContext context)
        {
            _webScrapingContext = context;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _webScrapingContext.Categoria.ToListAsync();
        }

        public async Task<Categoria> GetById(int id)
        {
            return await _webScrapingContext.Categoria.Where(x => x.IdCategoria == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Categoria categoria)
        {
            await _webScrapingContext.Categoria.AddAsync(categoria);
            int rows = await _webScrapingContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Categoria categoria)
        {
            _webScrapingContext.Categoria.Update(categoria);
            int rows = await _webScrapingContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var categoria = await _webScrapingContext.Categoria.FindAsync(id);
            if (categoria != null)
            {
                _webScrapingContext.Categoria.Remove(categoria);
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
