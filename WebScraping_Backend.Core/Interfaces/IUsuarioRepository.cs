using WebScraping_Backend.Core.Entities;

namespace WebScraping_Backend.Infrastructure.Repositories
{
    public interface IUsuarioRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario?> GetById(int id);
        Task<bool> Insert(Usuario usuario);
        Task<bool> IsEmailRegistered(string email);
        Task<Usuario?> SignIn(string email, string contraseña);
        Task<bool> SignUp(Usuario user);
        Task<bool> Update(Usuario usuario);
        Task<bool> UpdateUltimoAcceso(int idUsuario, DateTime ultimoAcceso);
    }
}