using System.Collections.Generic;
using System.Threading.Tasks;

namespace Przedszkole.Database.Services;

public class GenericDataService<T> : IDataService<T> where T : class
{
    private readonly AppDbContextFactory _contextFactory;


    public GenericDataService(AppDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    
    public Task<IEnumerable<T>> GetAll()
    {
        throw new System.NotImplementedException();
    }

    public Task<T> Get(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task<T> Create(T entity)
    {
        throw new System.NotImplementedException();
    }

    public Task<bool> Delete(T entity)
    {
        throw new System.NotImplementedException();
    }

    public Task<T> Update(T entity)
    {
        throw new System.NotImplementedException();
    }
}