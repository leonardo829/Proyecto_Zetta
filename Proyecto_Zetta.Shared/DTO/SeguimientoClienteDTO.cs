using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class SeguimientoClienteDTO
    {
    public string Estado { get; set; }
    public List<string> Comentarios { get; set; }
    public bool MantenimientoSN { get; set; }
    public string ClienteNombre { get; set; }
    public string ClienteDireccion { get; set; }
    public long? ClienteTelefono { get; set; }
    public string? ClienteMail { get; set; }
    public string ObraDescripcion { get; set; }
    }
}
