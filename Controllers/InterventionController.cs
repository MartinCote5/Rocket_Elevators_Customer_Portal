using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers;

public class InterventionController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public InterventionController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

public IActionResult Index()
    {
        return View();
    }   

}    