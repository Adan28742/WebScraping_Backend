using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraping_Backend.Infrastructure.Data;
using WebScraping_Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using WebScraping_Backend.Core.Interfaces;
using WebScraping_Backend.Core.DTOs;

namespace WebScraping_Backend.Infrastructure.Repositories
{
    public class VideoGeneradoRepository : IVideoGeneradoRepository
    {
        private readonly ProjectWebScrapingContext _webScrapingContext;

        public VideoGeneradoRepository(ProjectWebScrapingContext context)
        {
            _webScrapingContext = context;
        }

        public async Task<IEnumerable<VideoGenerado>> GetAll()
        {
            return await _webScrapingContext.VideoGenerado.ToListAsync();
        }

        public async Task<VideoGenerado> GetById(int id)
        {
            return await _webScrapingContext.VideoGenerado.Where(x => x.IdVideoGenerado == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(VideoGenerado videogenerado)
        {
            await _webScrapingContext.VideoGenerado.AddAsync(videogenerado);
            int rows = await _webScrapingContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(VideoGenerado videogenerado)
        {
            _webScrapingContext.VideoGenerado.Update(videogenerado);
            int rows = await _webScrapingContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var videogenerado = await _webScrapingContext.VideoGenerado.FindAsync(id);
            if (videogenerado != null)
            {
                _webScrapingContext.VideoGenerado.Remove(videogenerado);
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
