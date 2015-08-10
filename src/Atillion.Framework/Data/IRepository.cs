using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atillion.Framework.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T>GetAll();
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
          
    }
}
