using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestGreenAtom.DAL
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Insert(T entity);
        Task Insert(List<T> entities);
        Task Update(T entity);
        Task Delete(Guid id);
        Task<List<T>> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
    }
}
