using AutoMapper;
using Proyecto_Zetta.DB.Data.Entity;
using Proyecto_Zetta.Shared.DTO;

namespace Proyecto_Zetta.Server.UTIL
{
   
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Seguimiento, SeguimientoClienteDTO>()
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
            .ForMember(dest => dest.Comentarios, opt => opt.MapFrom(src => src.Comentarios.Select(c => c.Texto)))
            .ForMember(dest => dest.MantenimientoSN, opt => opt.MapFrom(src => src.Mantenimiento_SN))
            .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.Obra.Cliente.Nombre))
            .ForMember(dest => dest.ClienteDireccion, opt => opt.MapFrom(src => src.Obra.Cliente.Direccion))
            .ForMember(dest => dest.ClienteTelefono, opt => opt.MapFrom(src => src.Obra.Cliente.Telefono))
            .ForMember(dest => dest.ClienteMail, opt => opt.MapFrom(src => src.Obra.Cliente.Mail))
            .ForMember(dest => dest.ObraDescripcion, opt => opt.MapFrom(src => src.Obra.Descripcion));
        }
    }
}
