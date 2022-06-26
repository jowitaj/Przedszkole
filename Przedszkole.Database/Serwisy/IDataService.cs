using System.Collections.Generic;
using System.Threading.Tasks;

namespace Przedszkole.Database.Services;


public interface IDataService<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> Get(int id);
    Task<T> Create(T entity);
    Task<bool> Delete(T entity);
    Task<T> Update(T entity);
}