using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class SeguimientoDTO
    {
        public string Estado { get; set; }
        public string? Descripcion { get; set; }
        public bool Mantenimiento_SN { get; set; }
        public int ObraId { get; set; }
        public int MantenimientoId { get; set; }
    }

}
