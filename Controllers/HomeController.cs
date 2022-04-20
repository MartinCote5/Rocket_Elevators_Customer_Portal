using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Elevator[] elevators = new Elevator[]{};
        using (var client = new HttpClient())
            {   
                // client.BaseAddress = new Uri("https://localhost:7276/databaseName???/api/Elevators/4");
                // client.BaseAddress = new Uri("https://localhost:7276/api/Elevators/4");
                client.BaseAddress = new Uri("https://heroku-rocketelevators-martinc.herokuapp.com/api/");
                //HTTP GET
                Console.WriteLine("------------------------");
                Console.WriteLine("------------------------");
                Console.WriteLine("------------------------");
                Console.WriteLine("------------------------");
                Console.WriteLine("------------------------");
                Console.WriteLine("------------------------");
                Console.WriteLine("------------------------");
                var responseTask = client.GetAsync("Elevators/inactive");
                responseTask.Wait();

                var result = responseTask.Result;
                
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Elevator[]>();
                    readTask.Wait();

                    elevators = readTask.Result;

                    foreach (var elevator in elevators)
                    {
                        Console.WriteLine(elevator.Id);
                        Console.WriteLine("------------------------");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("------------------------");
                    }
                }
            }  
        return View(elevators);
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
