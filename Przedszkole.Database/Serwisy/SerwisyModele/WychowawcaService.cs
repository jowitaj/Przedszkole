using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Przedszkole.Database.Models;

namespace Przedszkole.Database.Services.SerwisyModele;

public class WychowawcaService
{
    private readonly IDataService<Wychowawca> _service;
    public WychowawcaService()
    {
        _service = new GenericDataService<Wychowawca>(new AppDbContextFactory());
    }
    
    /// <summary>
    /// Metoda na utworzenie obiektu Wychowawca oraz dodanie go do bazy danych do tabeli Wychowawcy
    /// </summary>
    /// <param name="imie"></param>
    /// <param name="nazwisko"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Wychowawca> Create(string imie, string nazwisko)
    {
        try
        {
            Wychowawca wychowawca = new Wychowawca()
            {
                Imie = imie,
                Nazwisko = nazwisko
            };
            return await _service.Create(wychowawca);
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
    /// <param name="imie"></param>
    /// <param name="nazwisko"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Wychowawca> Update(int id,string imie, string nazwisko)
    {
        try
        {
            Wychowawca wychowawcaDoZmiany = await GetById(id);
            wychowawcaDoZmiany.Imie = imie;
            wychowawcaDoZmiany.Nazwisko = nazwisko;
            return await _service.Update(wychowawcaDoZmiany);
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
    public Task<Wychowawca> GetById(int ID)
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
            Wychowawca doUsuniecia = await GetById(id);

            return await _service.Delete(doUsuniecia);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    /// <summary>
    /// Metoda na pobranie wszystkich rekordow z tabeli Wychowawcy
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<List<Wychowawca>> GetAll()
    {
        try
        {
            return (List<Wychowawca>) await _service.GetAll();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
}