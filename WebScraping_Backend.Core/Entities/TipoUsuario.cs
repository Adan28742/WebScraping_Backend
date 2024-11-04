using System;
using System.Collections.Generic;

namespace WebScraping_Backend.Core.Entities;

public partial class TipoUsuario
{
    public int IdTipoUsuario { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
