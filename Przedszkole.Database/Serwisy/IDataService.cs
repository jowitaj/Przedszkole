using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Przedszkole.Database.Services;


public interface IDataService<T>
{
    Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
    Task<T> Get(int id);
    Task<T> Create(T entity);
    Task<bool> Delete(T entity);
    Task<T> Update(T entity);
}