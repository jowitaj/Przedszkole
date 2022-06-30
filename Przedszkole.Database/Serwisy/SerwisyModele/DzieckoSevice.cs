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