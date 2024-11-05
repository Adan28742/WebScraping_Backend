using WebScraping_Backend.Core.Entities;

namespace WebScraping_Backend.Core.Interfaces
{
    public interface ILista_GuardadoRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ListaGuardado>> GetAll();
        Task<ListaGuardado> GetById(int id);
        Task<bool> Insert(ListaGuardado listaguardado);
        Task<bool> Update(ListaGuardado listaguardado);
    }
}