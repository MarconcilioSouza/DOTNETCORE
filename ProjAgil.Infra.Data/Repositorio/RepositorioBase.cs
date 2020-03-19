using System.Threading.Tasks;
using ProjAgil.Dominio.Interfaces.Repositorio;
using ProjAgil.Infra.Data.Context;

namespace ProjAgil.Infra.Data.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        public readonly ProAgilContext proAgilContext;
        public RepositorioBase(ProAgilContext proAgilContext)
        {
            this.proAgilContext = proAgilContext;
        }

        public void Add(T entity)
        {
            proAgilContext.Add(entity);
        }

        public void Delete(T entity)
        {
            proAgilContext.Remove(entity);
        }

        public void Update(T entity)
        {
            proAgilContext.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return (await proAgilContext.SaveChangesAsync()) > 0;
        }
    }
}