using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data;

namespace Proyecto_Zetta.Server.Repositorios
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IEntityBase
    {
        private readonly Context context;

        public Repositorio(Context context)
        {
            this.context = context;
        }

        public async Task<E> SelectById(int id)
        {
            E? sel = await context.Set<E>()
                .FirstOrDefaultAsync(
                x => x.Id == id);
            return sel;
        }

        public async Task<bool> Existe(int id)
        {
            var existe = await context.Set<E>()
                             .AnyAsync(x => x.Id == id);
            return existe;
        }

        public async Task<bool> Update(int id, E entidad)
        {
            if (id != entidad.Id)
            {
                return false;
            }
            var EntidadExistente = await SelectById(id);

            if (EntidadExistente == null)
            {
                return false;
            }

            try
            {
                context.Entry(EntidadExistente).CurrentValues.SetValues(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
