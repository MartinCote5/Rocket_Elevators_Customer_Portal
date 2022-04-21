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
    //var de mon cisti
        Customer customer = new Customer();
        Product product = new Product();
        // ViewBag.Elevators = elevators;
        using (var client = new HttpClient())
            {   
                
                // GET: api/Customers/{email}
                // GET: api/Customers/{email}

                // var x = .UserName;

                Console.WriteLine("----------identityname--------------");
                var user_email = User.Identity.Name;
                Console.WriteLine(user_email);
                Console.WriteLine("------------identityname------------");
                client.BaseAddress = new Uri("https://heroku-rocketelevators-martinc.herokuapp.com/api/");
                //HTTP GET
              
                Console.WriteLine("-----------heroku-------------");
                Console.WriteLine("------------------------");
                var responseTask = client.GetAsync($"Customers/leigh.cummerata@greenholt.com");
                responseTask.Wait();

                var result = responseTask.Result;
                
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("-----------success?------------");
                    var readTask = result.Content.ReadAsAsync<Customer>();
                    readTask.Wait();

                    customer = readTask.Result;
                    product.customer = customer;
                    responseTask = client.GetAsync($"Buildings/portal/{customer.Id}");
                    responseTask.Wait();

                    result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask2 = result.Content.ReadAsAsync<Building[]>();
                        readTask2.Wait();

                        Building[] buildings = readTask2.Result;

                        product.buildings = buildings;
                    }

                    // foreach (var elevator in customers)
                    // {
                    //     Console.WriteLine(customer.Id);
                        
                    // }
                }
            }  

        // Console.WriteLine("-----------customers-------------");
        // Console.WriteLine(customers.Id);
        // Console.WriteLine("-----------customers-------------");
        return View(product);
    
        







        // Elevator[] elevators = new Elevator[]{};
        // ViewBag.Elevators = elevators;
        // using (var client = new HttpClient())
        //     {   
        //         // client.BaseAddress = new Uri("https://localhost:7276/databaseName???/api/Elevators/4");
        //         // client.BaseAddress = new Uri("https://localhost:7276/api/Elevators/4");
        //         client.BaseAddress = new Uri("https://heroku-rocketelevators-martinc.herokuapp.com/api/");
        //         //HTTP GET
        //         Console.WriteLine("------------------------");
        //         Console.WriteLine("------------------------");
        //         Console.WriteLine("------------------------");
        //         Console.WriteLine("------------------------");
        //         Console.WriteLine("------------------------");
        //         Console.WriteLine("------------------------");
        //         Console.WriteLine("------------------------");
        //         var responseTask = client.GetAsync("Elevators/inactive");
        //         responseTask.Wait();

        //         var result = responseTask.Result;
                
        //         if (result.IsSuccessStatusCode)
        //         {

        //             var readTask = result.Content.ReadAsAsync<Elevator[]>();
        //             readTask.Wait();

        //             elevators = readTask.Result;

        //             foreach (var elevator in elevators)
        //             {
        //                 Console.WriteLine(elevator.Id);
        //                 Console.WriteLine("------------------------");
        //                 Console.WriteLine("------------------------");
        //                 Console.WriteLine("------------------------");
        //                 Console.WriteLine("------------------------");
        //                 Console.WriteLine("------------------------");
        //                 Console.WriteLine("------------------------");
        //                 Console.WriteLine("------------------------");
        //             }
        //         }
        //     }  
        // return View(elevators);
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
