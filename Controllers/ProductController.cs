using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
    
        Customer customer = new Customer();
        Building[] buildings = new Building[]{};
        Battery[] batteries = new Battery[]{};
        Column[] columns = new Column[]{};
        Elevator[] elevators = new Elevator[]{};
        Product product = new Product();
        
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
                var responseTask = client.GetAsync($"Customers/{user_email}");
                responseTask.Wait();

                var result = responseTask.Result;
                
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("-----------success?------------");
                    var readTask = result.Content.ReadAsAsync<Customer>();
                    readTask.Wait();

                    customer = readTask.Result;
                    product.customer = customer;
                    responseTask = client.GetAsync($"Customers/Products/{customer.Id}");
                    responseTask.Wait();

                    result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask2 = result.Content.ReadAsAsync<Product>();
                        readTask2.Wait();


                        Product customerProducts = new Product{
                            buildings = buildings,
                            batteries = batteries,
                            columns = columns,
                            elevators = elevators
                        };
                        customerProducts = readTask2.Result;
                        product = customerProducts;
                        Console.WriteLine("-----------buildinginfor------------");
                        Console.WriteLine(product);
                        Console.WriteLine("-----------buildinginfor------------");
                        
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
    }




    public IActionResult ElevatorEdit(long? id)
        {
            if (id == null) {
                return NotFound();
            }
            Elevator elevator = new Elevator();
            using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://heroku-rocketelevators-martinc.herokuapp.com/api/");
                    var responseTask = client.GetAsync($"Elevators/{id}");
                        responseTask.Wait();

                        var result = responseTask.Result;

                        if (result.IsSuccessStatusCode)
                        {
                            var readTask2 = result.Content.ReadAsAsync<Elevator>();
                            readTask2.Wait();

                            elevator = readTask2.Result;
                        }
                }
            return View(elevator);
    }



    public IActionResult BuildingEdit(long? id)
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
   

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BuildingEdit(int id, [Bind("Id, customer_id, full_name_of_the_building_administrator,email_of_the_administrator_of_the_building,Genre,phone_number_of_the_building_administrator")] Building building)
        {
            if (id != building.Id)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {   
                // var user_email = User.Identity.Name;
                client.BaseAddress = new Uri("https://heroku-rocketelevators-martinc.herokuapp.com/api/");

                var responseTask = client.PutAsJsonAsync<Building>($"Buildings/{id}", building);
                responseTask.Wait();

                var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {

                        Console.WriteLine("-----------put-------------");
                        Console.WriteLine(id);
                        Console.WriteLine("-----------put-------------");
                        // var readTask2 = result.Content.ReadAsAsync<Building>();
                        // readTask2.Wait();

                        // building = readTask2.Result;
                    }
                }

            return RedirectToAction(nameof(Index));
        }

}


        