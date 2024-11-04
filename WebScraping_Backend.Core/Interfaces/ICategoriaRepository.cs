using WebScraping_Backend.Core.Entities;

namespace WebScraping_Backend.Core.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Categoria>> GetAll();
        Task<Categoria> GetById(int id);
        Task<bool> Insert(Categoria categoria);
        Task<bool> Update(Categoria categoria);
    }
}