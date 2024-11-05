using WebScraping_Backend.Core.Entities;

namespace WebScraping_Backend.Core.Interfaces
{
    public interface IVideoGeneradoRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<VideoGenerado>> GetAll();
        Task<VideoGenerado> GetById(int id);
        Task<bool> Insert(VideoGenerado videogenerado);
        Task<bool> Update(VideoGenerado videogenerado);
    }
}