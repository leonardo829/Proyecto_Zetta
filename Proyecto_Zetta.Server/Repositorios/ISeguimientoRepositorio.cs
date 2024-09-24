using Proyecto_Zetta.DB.Data.Entity;

namespace Proyecto_Zetta.Server.Repositorios
{
    public interface ISeguimientoRepositorio
    {
        void Add(Seguimiento seguimiento);
        void Delete(int id);
        IEnumerable<Seguimiento> Get();
        Seguimiento GetById(int id);
        void Update(Seguimiento seguimiento);
    }
}