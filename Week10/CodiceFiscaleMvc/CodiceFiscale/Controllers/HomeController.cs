using BusinessLogic;
using DataLayer;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodiceFiscale.Models;

namespace CodiceFiscale.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        CF calcolo = new();
        PersonaDataViewModel x = new();
        x.FirstName = "Mirko";
        x.LastName = "Scata";
        x.Birthday = DateTime.Parse("1992-05-15");
        x.Istat = "Acireale";
        x.Gender = 'M';
        x.CodiceFiscale = calcolo.CalcolaCodiceFiscale(x);


        return View("Index",x.CodiceFiscale );
    }
  
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

