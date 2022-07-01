using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Przedszkole.Database.Models;

namespace Przedszkole.Database.Services.SerwisyModele;

public class DzieckoSevice
{
    private readonly IDataService<Dziecko> _service;
    public DzieckoSevice()
    {
        _service = new GenericDataService<Dziecko>(new AppDbContextFactory());
    }

    /// <summary>
    ///  Metoda na utworzenie obiektu Dziecko oraz dodanie go do bazy danych do tabeli Dzieci
    /// </summary>
    /// <param name="imie"></param>
    /// <param name="nazwisko"></param>
    /// <param name="rodziceId"></param>
    /// <param name="wychowawcaId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Dziecko> Create(string imie, string nazwisko,int rodziceId, int wychowawcaId)
    {
        try
        {
            Dziecko dziecko = new Dziecko()
            {
                Imie = imie,
                Nazwisko = nazwisko,
                RodziceId = rodziceId,
                WychowawcaId = wychowawcaId
            };
            return await _service.Create(dziecko);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    /// <summary>
    /// Metoda na edycje obiektu Dziecko z tabeli Dzieci
    /// </summary>
    /// <param name="id"></param>
    /// <param name="imie"></param>
    /// <param name="nazwisko"></param>
    /// <param name="rodziceId"></param>
    /// <param name="wychowawcaId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Dziecko> Update(int id,string imie, string nazwisko,int rodziceId, int wychowawcaId)
    {
        try
        {
            Dziecko dzieckoDoZmiany = await GetById(id);
            dzieckoDoZmiany.Imie = imie;
            dzieckoDoZmiany.Nazwisko = nazwisko;
            dzieckoDoZmiany.RodziceId= rodziceId;
            dzieckoDoZmiany.WychowawcaId = wychowawcaId;
             return await _service.Update(dzieckoDoZmiany);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    /// <summary>
    /// Metoda na pobieranie rekordu z bazy po ID
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Task<Dziecko> GetById(int ID)
    {
        try
        {
            return _service.Get(ID);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    /// <summary>
    /// Metoda na usuniecie rekordu z bazy po ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<bool> Delete(int id)
    {
        try
        {
            Dziecko dzieckoDoUsuniecia = await GetById(id);

            return await _service.Delete(dzieckoDoUsuniecia);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    /// <summary>
    /// Metoda na pobranie wszystkich rekordow z tabeli Dzieci
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<List<Dziecko>> GetAll()
    {
        try
        {
            return (List<Dziecko>) await _service.GetAll(x=>x.Rodzice, x=>x.Wychowawca);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    
    
}