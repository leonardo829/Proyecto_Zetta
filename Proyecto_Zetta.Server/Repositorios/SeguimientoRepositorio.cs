using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.Shared.DTO;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Proyecto_Zetta.Server.Repositorios
{
    public class SeguimientoRepositorio : ISeguimientoRepositorio
    {
        private readonly Context _context;
        private readonly IMapper mapper;

        public SeguimientoRepositorio(Context context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<IActionResult> GetSeguimientoid(int id)
        {
            var seguimiento = await _context.Seguimientos.FindAsync(id);
            if (seguimiento == null)
            {
                return NotFound();
            }

            var seguimientoDto = mapper.Map<SeguimientoClienteDTO>(seguimiento);

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(seguimientoDto, options);

            return Ok(json);
        }

        private IActionResult Ok(string json)
        {
            throw new NotImplementedException();
        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
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