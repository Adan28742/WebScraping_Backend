using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraping_Backend.Core.DTOs
{
    public class TipoUsuarioDTO
    {
        public int IdTipoUsuario { get; set; }

        public string Descripcion { get; set; } = null!;
    }

    public class TipoUsuarioInsertDTO
    {
        public string Descripcion { get; set; } = null!;
    }
}
