using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraping_Backend.Core.Entities;

namespace WebScraping_Backend.Core.DTOs
{
    public class VideoGeneradoDTO
    {
        public int IdVideoGenerado { get; set; }

        public int? IdCategoria { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string? Estado { get; set; }

        public int? Duracion { get; set; }

    }

    public class VideoGeneradoInsertDTO
    {
        public int? IdCategoria { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string? Estado { get; set; }

        public int? Duracion { get; set; }


    }
}
