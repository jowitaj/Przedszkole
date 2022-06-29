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