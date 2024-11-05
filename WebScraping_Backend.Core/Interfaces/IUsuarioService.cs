using WebScraping_Backend.Core.DTOs;

namespace WebScraping_Backend.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<UsuarioDTO>> GetAll();
        Task<UsuarioDTO?> GetById(int id);
        Task<bool> PostUser(UsuarioPostDTO usuarioPostDTO);
        Task<bool> Register(UsuarioAuthRequestDTO usuarioAuthRequestDTO);
        Task<bool> UpdatePassword(UsuarioUpdatePassDTO usuarioUpdatePassDTO);
        Task<bool> UpdateUser(UsuarioDTO updateDTO);
        Task<UsuarioAuthResponseDTO?> Validate(string email, string contraseña);
    }
}