using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraping_Backend.Core.Entities;

namespace WebScraping_Backend.Core.DTOs
{
    public class TipoGuardadoDTO
    {
        public int IdTipoGuardado { get; set; }

        public string Descripcion { get; set; } = null!;

    }

    public class TipoGuardadoInsertDTO
    {
        public string Descripcion { get; set; } = null!;
    }
}
