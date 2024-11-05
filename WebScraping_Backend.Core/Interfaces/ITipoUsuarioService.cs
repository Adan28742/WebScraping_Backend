using WebScraping_Backend.Core.DTOs;

namespace WebScraping_Backend.Core.Interfaces
{
    public interface ITipoUsuarioService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<TipoUsuarioDTO>> GetAll();
        Task<TipoUsuarioDTO?> GetById(int id);
        Task<bool> Insert(TipoUsuarioInsertDTO tipoUsuarioInsertDTO);
        Task<bool> Update(TipoUsuarioDTO tipoUsuarioDTO);
    }
}