using System.Threading.Tasks;

namespace ProjAgil.Dominio.Interfaces.Aplicacao
{
    public interface IAppServeceBase<T> where T : class
    {
         void Add(T entity);
         void Update(T entity);
         void Delete(T entity);
         Task<bool> SaveChangesAsync();
    }
}