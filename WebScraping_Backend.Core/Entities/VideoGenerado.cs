using System;
using System.Collections.Generic;

namespace WebScraping_Backend.Core.Entities;

public partial class VideoGenerado
{
    public int IdVideoGenerado { get; set; }

    public int? IdCategoria { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Estado { get; set; }

    public int? Duracion { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual ICollection<ListaGuardado> ListaGuardado { get; set; } = new List<ListaGuardado>();
}
