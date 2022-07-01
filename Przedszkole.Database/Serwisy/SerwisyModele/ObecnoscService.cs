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