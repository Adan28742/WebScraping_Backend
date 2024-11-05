using WebScraping_Backend.Core.Entities;

namespace WebScraping_Backend.Infrastructure.Repositories
{
    public interface ITipoUsuarioRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<TipoUsuario>> GetAll();
        Task<TipoUsuario> GetById(int id);
        Task<bool> Insert(TipoUsuario tipoUsuario);
        Task<bool> Update(TipoUsuario tipoUsuario);
    }
}