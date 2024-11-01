﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Server.Repositorios;
using Proyecto_Zetta.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/controller")]
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
        public ActionResult<SeguimientoDTO> GetSeguimientos()
        {
            var seguimientos = repositorio.Get();
            var seguimientosDto = mapper.Map<IEnumerable<SeguimientoDTO>>(seguimientos);
            return Ok(seguimientosDto);
        }

        [HttpGet("{id}")]
        public ActionResult<SeguimientoDTO> GetSeguimientoid(int id)
        {
            var seguimiento = repositorio.GetById(id);
            if (seguimiento == null) return NotFound();
            var seguimientoDto = mapper.Map<SeguimientoDTO>(seguimiento);
            return Ok(seguimientoDto);
        }

        [HttpPost]
        public ActionResult<SeguimientoDTO> CreateSeguimiento(SeguimientoDTO seguimientoDto)
        {
            var seguimiento = mapper.Map<Seguimiento>(seguimientoDto);
            repositorio.Add(seguimiento);
            return CreatedAtAction(nameof(GetSeguimientoid), new { id = seguimiento.Id }, seguimientoDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSeguimiento(int id, SeguimientoDTO seguimientoDto)
        {
            var seguimiento = repositorio.GetById(id);
            if (seguimiento == null) return NotFound();

            mapper.Map(seguimientoDto, seguimiento);
            repositorio.Update(seguimiento);
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //public ActionResult DeleteSeguimiento(int id)
        //{
        //    var seguimiento = repositorio.GetById(id);
        //    if (seguimiento == null) return NotFound();
        //    repositorio.Delete(id);
        //    return NoContent();
        //}
    }

}
// arreglar error de base de datosl al cargar, en seguimiento pide id mantenimiento sin importar que realice o no.
// mantenimiento pide presupuesto y presupuesto pide obra de nuevo 
// preguntar a cerca del seguimineto, si se modifica o no.  al profe
// dar opcion a agregar muchos comentarios?? consultar al profe como lo haria
