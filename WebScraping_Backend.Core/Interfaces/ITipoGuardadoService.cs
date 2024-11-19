using WebScraping_Backend.Core.DTOs;

namespace WebScraping_Backend.Core.Interfaces
{
    public interface ITipoGuardadoService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<TipoGuardadoDTO>> GetAll();
        Task<TipoGuardadoDTO?> GetById(int id);
        Task<bool> Insert(TipoGuardadoInsertDTO tipoGuardadoInsertDTO);
        Task<bool> Update(TipoGuardadoDTO tipoGuardadoDTO);
    }
}