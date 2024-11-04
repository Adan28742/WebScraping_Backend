using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraping_Backend.Core.DTOs
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }

        public string Descripcion { get; set; } = null!;
    }

    public class CategoriaInsertDTO
    {
        public string Descripcion { get; set; } = null!;
    }
}
