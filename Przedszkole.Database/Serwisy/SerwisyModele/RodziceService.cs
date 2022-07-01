using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Przedszkole.Database.Models;

namespace Przedszkole.Database.Services.SerwisyModele;

public class RodziceService
{
    private readonly IDataService<Rodzice> _service;

    public RodziceService()
    {
        _service = new GenericDataService<Rodzice>(new AppDbContextFactory());
    }

    /// <summary>
    /// Metoda na utworzenie obiektu Rodzice oraz dodanie go do bazy danych do tabeli Rodzice
    /// </summary>
    /// <param name="imieMatki"></param>
    /// <param name="nazwiskoMatki"></param>
    /// <param name="imieOjca"></param>
    /// <param name="nazwiskoOjca"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Rodzice> Create(string imieMatki, string nazwiskoMatki, string imieOjca, string nazwiskoOjca)
    {
        try
        {
            Rodzice rodzice = new Rodzice()
            {
                ImieMatki = imieMatki,
                NazwiskoMatki = nazwiskoMatki,
                ImieOjca = imieOjca,
                NazwiskoOjca = nazwiskoOjca,
            };
            return await _service.Create(rodzice);
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
    /// <param name="imieMatki"></param>
    /// <param name="nazwiskoMatki"></param>
    /// <param name="imieOjca"></param>
    /// <param name="nazwiskoOjca"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<Rodzice> Update(int id,string imieMatki, string nazwiskoMatki, string imieOjca, string nazwiskoOjca)
    {
        try
        {
            Rodzice rodziceDoZmiany = await GetById(id);
            rodziceDoZmiany.ImieMatki = imieMatki;
            rodziceDoZmiany.NazwiskoMatki = nazwiskoMatki;
            rodziceDoZmiany.ImieOjca= imieOjca;
            rodziceDoZmiany.NazwiskoOjca = nazwiskoOjca;
            return await _service.Update(rodziceDoZmiany);
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
    public Task<Rodzice> GetById(int ID)
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
            Rodzice doUsuniecia = await GetById(id);

            return await _service.Delete(doUsuniecia);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    /// <summary>
    /// Metoda na pobranie wszystkich rekordow z tabeli Rodzicow
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    
    public async Task<List<Rodzice>> GetAll()
    {
        try
        {
            return (List<Rodzice>) await _service.GetAll();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}