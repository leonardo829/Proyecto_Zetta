using Microsoft.AspNetCore.Mvc;
using Proyecto_Zetta.DB.Data.Entity;

namespace Proyecto_Zetta.Server.Repositorios
{
    public interface ISeguimientoRepositorio
    {
        void Add(Seguimiento seguimiento);
        IEnumerable<Seguimiento> Get();
        Seguimiento GetById(int id);
        Task<IActionResult> GetSeguimientoid(int id);
        void Update(Seguimiento seguimiento);
    }
}