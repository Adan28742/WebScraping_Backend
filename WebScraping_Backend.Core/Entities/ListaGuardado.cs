using System;
using System.Collections.Generic;

namespace WebScraping_Backend.Core.Entities;

public partial class ListaGuardado
{
    public int IdListaGuardado { get; set; }

    public int? IdVideoGenerado { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool? Estado { get; set; }

    public int? IdTipoGuardado { get; set; }

    public virtual TipoGuardado? IdTipoGuardadoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual VideoGenerado? IdVideoGeneradoNavigation { get; set; }
}
