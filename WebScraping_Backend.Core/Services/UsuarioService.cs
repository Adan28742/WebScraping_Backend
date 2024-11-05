using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraping_Backend.Core.DTOs;
using WebScraping_Backend.Core.Entities;
using WebScraping_Backend.Core.Interfaces;
using WebScraping_Backend.Infrastructure.Repositories;

namespace WebScraping_Backend.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAll()
        {
            var search = await _usuarioRepository.GetAll();
            return (search.Any()) ? search.Select(x => new UsuarioDTO
            {
                IdUsuario = x.IdUsuario,
                IdTipoUsuario = x.IdTipoUsuario,
                Nombres = x.Nombres,
                Apellidos = x.Apellidos,
                FechaNacimiento = x.FechaNacimiento,
                Email = x.Email,
                Password = x.Password,
                Estado = x.Estado,
                FechaCreacion = x.FechaCreacion,
                Telefono = x.Telefono,
                UltimoAcceso = x.UltimoAcceso,

            }) : Enumerable.Empty<UsuarioDTO>();
        }
        public async Task<UsuarioDTO?> GetById(int id)
        {
            var x = await _usuarioRepository.GetById(id);
            return (x != null) ? new UsuarioDTO
            {
                IdUsuario = x.IdUsuario,
                IdTipoUsuario = x.IdTipoUsuario,
                Nombres = x.Nombres,
                Apellidos = x.Apellidos,
                FechaNacimiento = x.FechaNacimiento,
                Email = x.Email,
                Password = x.Password,
                Estado = x.Estado,
                FechaCreacion = x.FechaCreacion,
                Telefono = x.Telefono,
                UltimoAcceso = x.UltimoAcceso,
            } : null;
        }

        public async Task<bool> PostUser(UsuarioPostDTO usuarioPostDTO)
        {
            return await _usuarioRepository.Insert(new Usuario
            {
                IdTipoUsuario = usuarioPostDTO.IdTipoUsuario,
                Nombres = usuarioPostDTO.Nombres,
                Apellidos = usuarioPostDTO.Apellidos,
                FechaNacimiento = usuarioPostDTO.FechaNacimiento,
                Email = usuarioPostDTO.Email,
                Password = usuarioPostDTO.Password,
                Estado = usuarioPostDTO.Estado,
                FechaCreacion = DateTime.Now,
                Telefono = usuarioPostDTO.Telefono,
                UltimoAcceso = DateTime.Now,
            });
        }
        public async Task<bool> UpdateUser(UsuarioDTO updateDTO)
        {
            var capture = await _usuarioRepository.GetById(updateDTO.IdUsuario);
            if (capture != null)
            {
                capture.IdTipoUsuario = updateDTO.IdTipoUsuario;
                capture.Nombres = updateDTO.Nombres;
                capture.Apellidos = updateDTO.Apellidos;
                capture.FechaNacimiento = updateDTO.FechaNacimiento;
                capture.Email = updateDTO.Email;
                capture.Password = updateDTO.Password;
                capture.Estado = updateDTO.Estado;
                capture.FechaCreacion = updateDTO.FechaCreacion;
                capture.Telefono = updateDTO.Telefono;
                capture.UltimoAcceso = updateDTO.UltimoAcceso;
                return await _usuarioRepository.Update(capture);
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> UpdatePassword(UsuarioUpdatePassDTO usuarioUpdatePassDTO)
        {
            try
            {
                if (usuarioUpdatePassDTO.IdUsuario == null)
                {
                    throw new ArgumentNullException(nameof(usuarioUpdatePassDTO.IdUsuario), "IdTipoUsuario no puede ser null.");
                }
                int idTipoUsuario = Convert.ToInt32(usuarioUpdatePassDTO.IdUsuario);
                var usuario = await _usuarioRepository.GetById(idTipoUsuario);
                if (usuario == null)
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(usuarioUpdatePassDTO.Password))
                {
                    throw new ArgumentException("La contraseña no puede estar vacía.", nameof(usuarioUpdatePassDTO.Password));
                }
                usuario.Password = (usuarioUpdatePassDTO.Password);
                bool updateResult = await _usuarioRepository.Update(usuario);
                return updateResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la contraseña: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            return await _usuarioRepository.Delete(id);
        }
        public async Task<UsuarioAuthResponseDTO?> Validate(string email, string contraseña)
        {
            var user = await _usuarioRepository.SignIn(email, contraseña);
            if (user == null)
            {
                return null;
            }

            // Actualizamos el campo `UltimoAcceso` a la hora actual.
            user.UltimoAcceso = DateTime.Now;
            await _usuarioRepository.UpdateUltimoAcceso(user.IdUsuario, (DateTime)user.UltimoAcceso);

            var userDTO = new UsuarioAuthResponseDTO()
            {
                IdUsuario = user.IdUsuario,
                IdTipoUsuario = (int)user.IdTipoUsuario,
                Nombres = user.Nombres,
                Apellidos = user.Apellidos,
                FechaNacimiento = user.FechaNacimiento,
                Email = user.Email,
                Estado = "1",
                FechaCreacion = user.FechaCreacion,
                Telefono = user.Telefono,
                UltimoAcceso = user.UltimoAcceso,
            };
            return userDTO;
        }


        public async Task<bool> Register(UsuarioAuthRequestDTO usuarioAuthRequestDTO)
        {
            var emailResult = await _usuarioRepository.IsEmailRegistered(usuarioAuthRequestDTO.Email);
            if (emailResult)
            {
                return false;
            }
            var user = new Usuario()
            {
                IdTipoUsuario = usuarioAuthRequestDTO.IdTipoUsuario,
                Nombres = usuarioAuthRequestDTO.Nombres,
                Apellidos = usuarioAuthRequestDTO.Apellidos,
                FechaNacimiento = usuarioAuthRequestDTO.FechaNacimiento,
                Email = usuarioAuthRequestDTO.Email,
                Password = usuarioAuthRequestDTO.Password,
                Estado = "1",
                FechaCreacion = DateTime.Now,
                Telefono = usuarioAuthRequestDTO.Telefono,
                UltimoAcceso = DateTime.Now,

            };
            var result = await _usuarioRepository.SignUp(user);
            return result;
        }

    }
}
