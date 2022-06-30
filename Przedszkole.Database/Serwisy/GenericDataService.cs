using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Przedszkole.Database.Services;

public class GenericDataService<T> : IDataService<T> where T : class
{
    private readonly AppDbContextFactory _contextFactory;
    private readonly NonQueryDataService<T> _nonQueryData;


    public GenericDataService(AppDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryData = new NonQueryDataService<T>(contextFactory);
    }
    
    
    public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
    {
        using AppDbContext context = _contextFactory.CreateDbContext();
        IQueryable<T> query = context.Set<T>();
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.ToListAsync();
    }

    public async Task<T> Get(int id)
    {
        using AppDbContext context = _contextFactory.CreateDbContext();
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<T> Create(T entity)
    {
        return await _nonQueryData.Create(entity);
    }

    public async Task<bool> Delete(T entity)
    {
        return await _nonQueryData.Delete(entity);
    }

    public async Task<T> Update(T entity)
    {
        return await _nonQueryData.Update(entity);
    }
}