using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Shared.DTO
{
    public class SeguimientoClienteDTO
    {
        public int Id { get; set; }
        public string Estado { get; set; } = "sin iniciar"; // sin iniciar, iniciado, terminado de la entidad seguimiento
        public List<string>? Comentarios { get; set; } // dato Texto de la entidad Comentarios
    public bool MantenimientoSN { get; set; } //mantenimiento si o no de la entidad seguimiento 
    public string ClienteNombre { get; set; } //nombre del cliente de la entidad Cliente
    public string ClienteDireccion { get; set; } //direccion del cliente de la entidad Cliente
        public long? ClienteTelefono { get; set; }//Telefono del cliente de la entidad Cliente
        public string? ClienteMail { get; set; } //mail del cliente de la entidad Cliente
        public string? ObraDescripcion { get; set; } //Descripcion de la obra de la entidad Obra
        public string NuevoComentario { get; set; } //almacena el comentario agregado para guardarlo
    }
}
