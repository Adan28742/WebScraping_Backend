using WebScraping_Backend.Core.Entities;

namespace WebScraping_Backend.Core.Interfaces
{
    public interface ITipoGuardadoRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<TipoGuardado>> GetAll();
        Task<TipoGuardado> GetById(int id);
        Task<bool> Insert(TipoGuardado tipoGuardado);
        Task<bool> Update(TipoGuardado tipoGuardado);
    }
}