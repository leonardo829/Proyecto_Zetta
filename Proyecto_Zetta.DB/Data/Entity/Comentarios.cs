using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.DB.Data.Entity
{
    public class Comentario : EntityBase
    {

        [MaxLength(500, ErrorMessage = "Maximo numero de caracteres {1}.")]
        public string? Texto { get; set; }
        public DateTime Fecha { get; set; }

        // Clave foránea 
        public int SeguimientoId { get; set; }
        public Seguimiento Seguimiento { get; set; }
    }
}
