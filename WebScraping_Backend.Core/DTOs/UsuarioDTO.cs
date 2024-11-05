using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraping_Backend.Core.DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        public int? IdTipoUsuario { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public DateTime? FechaNacimiento { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Estado { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string? Telefono { get; set; }

        public DateTime? UltimoAcceso { get; set; }
    }

    public class UsuarioPostDTO
    {
        public int IdTipoUsuario { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public DateTime? FechaNacimiento { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Estado { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string? Telefono { get; set; }

        public DateTime? UltimoAcceso { get; set; }

    }
    public class UsuarioUpdatePassDTO
    {
        public int? IdUsuario { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
    public class UsuarioAuthenticationDTO
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
    public class UsuarioAuthRequestDTO
    {
        public int? IdTipoUsuario { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public DateTime? FechaNacimiento { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Estado { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string? Telefono { get; set; }

        public DateTime? UltimoAcceso { get; set; }
    }
    public class UsuarioAuthResponseDTO {

        public int IdUsuario { get; set; }

        public int IdTipoUsuario { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public DateTime? FechaNacimiento { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Estado { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string? Telefono { get; set; }

        public DateTime? UltimoAcceso { get; set; }

    }
}
