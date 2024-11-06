using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Repositorios
{
    public class SeguimientoRepositorio : ISeguimientoRepositorio
    {
        private readonly Context _context;

        public SeguimientoRepositorio(Context context)
        {
            _context = context;
        }

        public SeguimientoClienteDTO GetSeguimientoConCliente(int seguimientoId)
        {
            return _context.Seguimientos
                .Where(s => s.Id == seguimientoId)
                .Include(s => s.Obra)
                .ThenInclude(p => p.Cliente)
                .Include(c => c.)
                .Select(s => new SeguimientoClienteDTO
                {
                    Estado = s.Estado,
                    Comentarios = .,
                    MantenimientoSN = s.MantenimientoSN,
                    ClienteNombre = s.Obra.Cliente.Nombre,
                    ClienteDireccion = s.Obra.Cliente.Direccion,
                    ClienteTelefono = s.Obra.Cliente.Telefono,
                    ClienteMail = s.Obra.Cliente.Mail,
                    ObraDescripcion = s.Obra.Descripcion
                })
                .FirstOrDefault();
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