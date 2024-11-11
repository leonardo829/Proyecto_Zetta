using Proyecto_Zetta.DB.Data.Entity;

namespace Proyecto_Zetta.Server.Repositorios
{
    public interface ISeguimientoRepositorio
    {
        Task<List<Seguimiento>> GetAll();
        Task<Seguimiento> GetById(int id);
        void Update(Seguimiento seguimiento);
    }
}