using WebScraping_Backend.Core.DTOs;

namespace WebScraping_Backend.Core.Interfaces;

public interface ILista_GuardadoService
{
    Task<bool> Delete(int id);
    Task<IEnumerable<Lista_GuardadoDTO>> GetAll();
    Task<Lista_GuardadoDTO?> GetById(int id);
    Task<bool> Insert(Lista_GuardadoInsertDTO video_generadoInsertDTO);
    Task<bool> Update(Lista_GuardadoDTO video_generadoDTO);
}