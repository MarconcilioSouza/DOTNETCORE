using System.Threading.Tasks;

namespace ProjAgil.Dominio.Interfaces.Aplicacao
{
    public interface IAppServeceBase<T> where T : class
    {
         T Add(T entity);
         T Update(T entity);
         void Delete(T entity);
         Task<bool> SaveChangesAsync();
    }
}