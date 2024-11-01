using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.DB.Data;

namespace Proyecto_Zetta.Server.Repositorios
{
    public class SeguimientoRepositorio : ISeguimientoRepositorio
    {
        private readonly Context _context;

        public SeguimientoRepositorio(Context context)
        {
            _context = context;
        }

        public IEnumerable<Seguimiento> Get()
        {
            return _context.Set<Seguimiento>().ToList();
        }

        public Seguimiento GetById(int id)
        {
            return _context.Set<Seguimiento>().Find(id);
        }

        public void Add(Seguimiento seguimiento)
        {
            _context.Set<Seguimiento>().Add(seguimiento);
            _context.SaveChanges();
        }

        public void Update(Seguimiento seguimiento)
        {
            _context.Set<Seguimiento>().Update(seguimiento);
            _context.SaveChanges();
        }

        //public void Delete(int id)
        //{
        //    var seguimiento = GetById(id);
        //    if (seguimiento != null)
        //    {
        //        _context.Set<Seguimiento>().Remove(seguimiento);
        //        _context.SaveChanges();
        //    }
        //}
    }
}