using System;
using System.Collections.Generic;

namespace WebScraping_Backend.Core.Entities;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<VideoGenerado> VideoGenerado { get; set; } = new List<VideoGenerado>();
}
