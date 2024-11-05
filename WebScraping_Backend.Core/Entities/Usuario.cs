using System;
using System.Collections.Generic;

namespace WebScraping_Backend.Core.Entities;

public partial class Usuario
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

    public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }

    public virtual ICollection<ListaGuardado> ListaGuardado { get; set; } = new List<ListaGuardado>();
}
