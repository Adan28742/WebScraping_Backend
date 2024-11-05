using System;
using System.Collections.Generic;

namespace WebScraping_Backend.Core.Entities;

public partial class TipoGuardado
{
    public int IdTipoGuardado { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<ListaGuardado> ListaGuardado { get; set; } = new List<ListaGuardado>();
}
