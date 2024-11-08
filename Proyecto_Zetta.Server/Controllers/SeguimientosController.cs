using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Server.Repositorios;
using Proyecto_Zetta.Shared.DTO;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/Seguimientos")]
    public class SeguimientosController : ControllerBase
    {
        private readonly ISeguimientoRepositorio repositorio;
        private readonly IMapper mapper;

        public SeguimientosController(ISeguimientoRepositorio repositorio, IMapper mapper)
        {
           this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSeguimientoid(int id)
        {
            var seguimiento = await repositorio.GetSeguimientoid(id);

            if (seguimiento == null)
            {
                return NotFound();
            }

            var seguimientoDto = mapper.Map<SeguimientoClienteDTO>(seguimiento);

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(seguimientoDto, options);

            return Ok(json);
        }

        [HttpPost]
        public ActionResult<Seguimiento> CreateSeguimiento(Seguimiento seguimiento)
        {
            var Seguimiento = mapper.Map<Seguimiento>(seguimiento);
            repositorio.Add(seguimiento);
            return CreatedAtAction(nameof(GetSeguimientoid), new { id = seguimiento.Id }, seguimiento);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSeguimiento(int id, Seguimiento seguimiento)
        {
            var Seguimiento = repositorio.GetById(id);
            if (seguimiento == null) return NotFound();

            mapper.Map(seguimiento, seguimiento);
            repositorio.Update(seguimiento);
            return NoContent();
        }

    }

}


//[HttpDelete("{id}")]
//public ActionResult DeleteSeguimiento(int id)
//{
//    var seguimiento = repositorio.GetById(id);
//    if (seguimiento == null) return NotFound();
//    repositorio.Delete(id);
//    return NoContent();
//}


