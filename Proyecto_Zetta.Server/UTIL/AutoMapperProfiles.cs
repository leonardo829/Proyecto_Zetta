using AutoMapper;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.UTIL
{
   
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Seguimiento, SeguimientoDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
