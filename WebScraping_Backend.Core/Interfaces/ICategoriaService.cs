using WebScraping_Backend.Core.DTOs;

namespace WebScraping_Backend.Core.Interfaces
{
    public interface ICategoriaService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<CategoriaDTO>> GetAll();
        Task<CategoriaDTO?> GetById(int id);
        Task<bool> Insert(CategoriaInsertDTO categoriaInsertDTO);
        Task<bool> Update(CategoriaDTO categoriaDTO);
    }
}