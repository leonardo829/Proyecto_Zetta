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

        public SeguimientoRepositorio(Context context)
        {
            this._context = context;
        }

        public async Task<List<Seguimiento>> GetAll()
        {
            return await _context.Seguimientos
                .Include(a => a.Obra)
                .ThenInclude(c => c.Cliente)
                .Include(co => co.Comentarios)
                .Include(m => m.Mantenimiento)
                .ToListAsync();
        }

        public async Task<Seguimiento> GetById(int id)
        {
            return await _context.Seguimientos
                .Include(b => b.Obra)
                .Include(c => c.Obra.Cliente)
                .Include(co => co.Comentarios)
                .Include(m => m.Mantenimiento)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task Update(Seguimiento seguimiento)
        {
            _context.Set<Seguimiento>().Update(seguimiento);
            await _context.SaveChangesAsync();
        }

    }
}

//public void Add(Seguimiento seguimiento)
//{
//    _context.Set<Seguimiento>().Add(seguimiento);
//    _context.SaveChanges();
//}

//public void Delete(int id)
//{
//    var seguimiento = GetById(id);
//    if (seguimiento != null)
//    {
//        _context.Set<Seguimiento>().Remove(seguimiento);
//        _context.SaveChanges();
//    }
//}