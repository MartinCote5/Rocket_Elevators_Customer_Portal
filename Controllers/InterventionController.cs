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




    public IActionResult InterventionGet(long? id)
        {
            if (id == null) {
                return NotFound();
            }
            Building building = new Building();
            using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://heroku-rocketelevators-martinc.herokuapp.com/api/");
                    var responseTask = client.GetAsync($"Buildings/{id}");
                        responseTask.Wait();

                        var result = responseTask.Result;

                        if (result.IsSuccessStatusCode)
                        {
                            var readTask2 = result.Content.ReadAsAsync<Building>();
                            readTask2.Wait();

                            building = readTask2.Result;
                        }
                }
            return View(building);
        }
}    