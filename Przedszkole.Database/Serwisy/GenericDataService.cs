using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Przedszkole.Database.Services;
/// <summary>
/// Klasa udostepniajaca metody do dzialania na generycznych klasach z bazy danych wraz z wczytywaniem
/// </summary>
/// <typeparam name="T"></typeparam>
public class GenericDataService<T> : IDataService<T> where T : class
{
    private readonly AppDbContextFactory _contextFactory;
    private readonly NonQueryDataService<T> _nonQueryData;


    public GenericDataService(AppDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
        _nonQueryData = new NonQueryDataService<T>(contextFactory);
    }
    
    /// <summary>
    /// Metoda na pobranie wszystkich rekordow z tabeli 
    /// </summary>
    /// <param name="includeProperties"></param>
    /// <returns></returns>
    public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
    {
        using AppDbContext context = _contextFactory.CreateDbContext();
        IQueryable<T> query = context.Set<T>();
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.ToListAsync();
    }
    /// <summary>
    /// Metoda na pobranie jednego rekordu po id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<T> Get(int id)
    {
        using AppDbContext context = _contextFactory.CreateDbContext();
        return await context.Set<T>().FindAsync(id);
    }
    /// <summary>
    /// Metoda na utworzenie obiektu klasy generycznej z tabeli
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<T> Create(T entity)
    {
        return await _nonQueryData.Create(entity);
    }

    /// <summary>
    /// Metoda na usuniecie obiektu klasy generycznej z tabeli
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<bool> Delete(T entity)
    {
        return await _nonQueryData.Delete(entity);
    }

    /// <summary>
    /// Metoda do edytyowania obiektu klasy generycznej z tabeli
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<T> Update(T entity)
    {
        return await _nonQueryData.Update(entity);
    }
}