using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Przedszkole.Database.Models;

namespace Przedszkole.Database.Services.SerwisyModele;

public class ObecnoscService
{
    private readonly IDataService<Obecnosc> _service;
    public ObecnoscService()
    {
        _service = new GenericDataService<Obecnosc>(new AppDbContextFactory());
    }
    
    /// <summary>
    /// Metoda na utworzenie obiektu Obecnosc oraz dodanie go do bazy danych do tabeli Obecnosci
    /// </summary>
    /// <param name="data"></param>
    /// <param name="dzieckoId"></param>
    /// <param name="obecny"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Obecnosc> Create(DateTime data, int dzieckoId, bool obecny)
    {
        try
        {
            Obecnosc obecnosc = new Obecnosc()
            {
                Data = data,
                DzieckoId = dzieckoId,
                Obecny = obecny
            };
            return await _service.Create(obecnosc);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    /// <summary>
    /// Metoda na edycje obiektu z tabeli w bazie danych
    /// </summary>
    /// <param name="id"></param>
    /// <param name="data"></param>
    /// <param name="dzieckoId"></param>
    /// <param name="obecny"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Obecnosc> Update(int id,DateTime data, int dzieckoId, bool obecny)
    {
        try
        {
            Obecnosc obecnoscDoZmiany = await GetById(id);
            obecnoscDoZmiany.Data = data;
            obecnoscDoZmiany.DzieckoId = dzieckoId;
            obecnoscDoZmiany.Obecny = obecny;
            
            return await _service.Update(obecnoscDoZmiany);
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
    public Task<Obecnosc> GetById(int ID)
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
            Obecnosc doUsuniecia = await GetById(id);

            return await _service.Delete(doUsuniecia);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    /// <summary>
    /// Metoda na pobranie wszystkich rekordow z tabeli Obecnosci
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<List<Obecnosc>> GetAll()
    {
        try
        {
            return (List<Obecnosc>) await _service.GetAll(x=>x.Dziecko);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}