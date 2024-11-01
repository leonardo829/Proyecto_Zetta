using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Servicios
{
    public interface ISClienteServicio
    {
        Task<SeguimientoClienteDTO> ObtenerClientePorObraId(int obraId);
    }
}