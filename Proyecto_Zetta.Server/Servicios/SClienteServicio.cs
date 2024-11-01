using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.Servicios
{
    public class SClienteServicio : ISClienteServicio
    {
        private readonly Context _context;
        private readonly Mapper mapper;

        public SClienteServicio(Context context, Mapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<SeguimientoClienteDTO> ObtenerClientePorObraId(int obraId)
        {
            var cliente = await _context.Presupuestos
                .Where(p => p.ObraId == obraId)
                .Select(p => p.Cliente)
                .FirstOrDefaultAsync();

            if (cliente == null)
            {
                return null;
            }

            try
            {
                var clienteDto = mapper.Map<SeguimientoClienteDTO>(cliente);
                return clienteDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la solicitud", ex);
            }
        }
    }
}

