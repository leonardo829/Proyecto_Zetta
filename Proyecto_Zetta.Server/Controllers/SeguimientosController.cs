using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Server.Repositorios;
using Proyecto_Zetta.Shared.DTO;


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

        [HttpGet]
        public async Task<ActionResult<List<SeguimientoClienteDTO>>> GetSeguimientos()
        {
            var seguimiento = await repositorio.GetAll();
            var SeguimientoClienteDTO = mapper.Map<List<SeguimientoClienteDTO>>(seguimiento);
            return Ok(SeguimientoClienteDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SeguimientoClienteDTO>> GetById(int id)
        {
            var seguimiento = await repositorio.GetById(id);
            if (seguimiento == null) return NotFound();
            return Ok(seguimiento);
        }

        [HttpPost("{id}/comentarios")] 
        public async Task<ActionResult> AddComentario(int id, [FromBody] string comentario) 
        { 
            var seguimiento = await repositorio.GetById(id); 
            if (seguimiento == null) 
                return NotFound(); 
            if (seguimiento.Comentarios == null) 
            { 
                seguimiento.Comentarios = new List<Comentario>(); 
            } 
            seguimiento.Comentarios.Add(new Comentario { Texto = comentario, Fecha = DateTime.Now }); 
            await repositorio.Update(seguimiento); 
            return Ok(new { mensaje = "Comentario agregado con éxito" }); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSeguimiento(int id, [FromBody] SeguimientoClienteDTO seguimientoDto)
        {
            var seguimiento = await repositorio.GetById(id);
            if (seguimiento == null) return NotFound();

            mapper.Map(seguimientoDto, seguimiento);
            await repositorio.Update(seguimiento);
            return NoContent();
        }


    }

}

//[HttpPost]
//public ActionResult<Seguimiento> CreateSeguimiento(Seguimiento seguimiento)
//{
//    var Seguimiento = mapper.Map<Seguimiento>(seguimiento);
//    repositorio.Add(seguimiento);
//    return CreatedAtAction(nameof(GetSeguimientoid), new { id = seguimiento.Id }, seguimiento);
//}
//[HttpDelete("{id}")]
//public ActionResult DeleteSeguimiento(int id)
//{
//    var seguimiento = repositorio.GetById(id);
//    if (seguimiento == null) return NotFound();
//    repositorio.Delete(id);
//    return NoContent();
//}


