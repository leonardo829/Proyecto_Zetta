using Proyecto_Zetta.DB.Data;

namespace Proyecto_Zetta.Server.Repositorios
{
    public interface IRepositorio<E> where E : class, IEntityBase
    {
        Task<bool> Existe(int id);
        Task<E> SelectById(int id);
        Task<bool> Update(int id, E entidad);
    }
}