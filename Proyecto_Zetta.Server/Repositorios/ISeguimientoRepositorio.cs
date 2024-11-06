using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Repositorios
{
    public interface ISeguimientoRepositorio
    {
        void Add(Seguimiento seguimiento);
        //void Delete(int id);
        IEnumerable<Seguimiento> Get();
        Seguimiento GetById(int id);
        SeguimientoClienteDTO GetSeguimientoConCliente(int seguimientoId);
        void Update(Seguimiento seguimiento);
    }
}