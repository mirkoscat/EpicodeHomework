﻿using BusinessLogic;
using DataLayer;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;

namespace CodiceFiscale.Controllers;

public class CFController : Controller
{
    
    private readonly ICodiceFiscale _calcolo;
    private readonly ComuniContext _comuni;

    public CFController(ICodiceFiscale codice, ComuniContext comuni)
    {
        _calcolo = codice;
        _comuni = comuni;
    }

    public async Task<IActionResult> Index()
    {
   
        var x = new PersonaDataViewModel() { CodiceFiscale=""};
   
        return View("Index",x);

    }

    [HttpPost]
    public async Task<IActionResult> Index(PersonaDataViewModel x)
    {
        if (ModelState.IsValid) { 
        try
        {
            
            x.Istat = _comuni.Comunis.FirstOrDefault(y => y.Comune == x.Istat).Code;
            x.CodiceFiscale = _calcolo.CalcolaCodiceFiscale(x);
        }catch(Exception e) { return RedirectToAction("Index"); }
		}
		return View("Index", x);
    }



    public async Task<IActionResult> CodiceFiscale(PersonaDataViewModel x)
    {
        try
        {
            //convertire ad asincrono
            x.Istat = _comuni.Comunis.FirstOrDefault(y => y.Comune == x.Istat).Code;
            x.CodiceFiscale = _calcolo.CalcolaCodiceFiscale(x);
        }
        catch (Exception e) { BadRequest(); }

        return Ok(x.CodiceFiscale );
    }


    public async Task<IActionResult> GetComuni(string? id)
    {
        List<Comuni> comuni = new();

        if (!string.IsNullOrEmpty(id))
        {
               comuni = await _comuni.Comunis.Where(x => x.Sigla == id).ToListAsync();
        }
        else
        {
            comuni = await _comuni.Comunis.ToListAsync();
        }
     

        return  Ok(comuni);
    }


    


}

