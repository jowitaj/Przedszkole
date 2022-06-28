using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Przedszkole.Database.Services;

public class NonQueryDataService<T> where T : class
{
    private readonly NonQueryDataService<T> _nonQueryData;
    private readonly AppDbContextFactory _contextFactory;

    public NonQueryDataService(AppDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    public async Task<T> Create(T entity)
    {
 
        using AppDbContext context = _contextFactory.CreateDbContext();
        EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
        return createdResult.Entity;
    }
 
    public async Task<bool> Delete(T entity)
    {
 
        using AppDbContext context = _contextFactory.CreateDbContext();
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
 
 
    public async Task<T> Update(T entity)
    {
        using AppDbContext context = _contextFactory.CreateDbContext();
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

}