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
    public class ListaGuardadoRepository : ILista_GuardadoRepository
    {
        private readonly ProjectWebScrapingContext _webScrapingContext;

        public ListaGuardadoRepository(ProjectWebScrapingContext context)
        {
            _webScrapingContext = context;
        }

        public async Task<IEnumerable<ListaGuardado>> GetAll()
        {
            return await _webScrapingContext.ListaGuardado.ToListAsync();
        }

        public async Task<ListaGuardado> GetById(int id)
        {
            return await _webScrapingContext.ListaGuardado.Where(x => x.IdVideoGenerado == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(ListaGuardado listaguardado)
        {
            await _webScrapingContext.ListaGuardado.AddAsync(listaguardado);
            int rows = await _webScrapingContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(ListaGuardado listaguardado)
        {
            _webScrapingContext.ListaGuardado.Update(listaguardado);
            int rows = await _webScrapingContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var listaguardado = await _webScrapingContext.ListaGuardado.FindAsync(id);
            if (listaguardado != null)
            {
                _webScrapingContext.ListaGuardado.Remove(listaguardado);
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
