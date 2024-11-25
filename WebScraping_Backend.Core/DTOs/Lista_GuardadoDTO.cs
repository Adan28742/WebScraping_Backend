using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraping_Backend.Core.Entities;

namespace WebScraping_Backend.Core.DTOs
{
    public class Lista_GuardadoDTO
    {
        public int IdVideoGenerado { get; set; }

        public int IdUsuario { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public bool? Estado { get; set; }

        public int? IdTipoGuardado { get; set; }

    }

    public class Lista_GuardadoInsertDTO
    {
        public int IdVideoGenerado { get; set; }

        public int IdUsuario { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public bool? Estado { get; set; }

        public int? IdTipoGuardado { get; set; }


    }
}
