using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Przedszkole.Database.Services;
/// <summary>
/// Klasa udostepniajaca metody do dzialania na generycznych klasach z bazy danych bez wczytywania danych
/// </summary>
/// <typeparam name="T"></typeparam>
public class NonQueryDataService<T> where T : class
{
    private readonly NonQueryDataService<T> _nonQueryData;
    private readonly AppDbContextFactory _contextFactory;

    /// <summary>
    /// Konstruktor 
    /// </summary>
    /// <param name="contextFactory"></param>
    public NonQueryDataService(AppDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    /// <summary>
    /// Metoda na dodanie obiektu klasy generycznej T do tabeli z ta klasa
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<T> Create(T entity)
    {
 
        using AppDbContext context = _contextFactory.CreateDbContext();
        EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
        return createdResult.Entity;
    }
 /// <summary>
 /// Usuniecie obiektu generycznego klasy T z tabeli z ta klasa
 /// </summary>
 /// <param name="entity"></param>
 /// <returns></returns>
    public async Task<bool> Delete(T entity)
    {
 
        using AppDbContext context = _contextFactory.CreateDbContext();
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
 /// <summary>
 /// Metoda na edycje obiektu klasy generycznej T do tabeli z ta klasa
 /// </summary>
 /// <param name="entity"></param>
 /// <returns></returns>
 
    public async Task<T> Update(T entity)
    {
        using AppDbContext context = _contextFactory.CreateDbContext();
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

}