// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using System.Net.Http;
// using System.Net.Http.Headers;


// namespace MvcMovie.Models
// {   
    
    
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             using (var client = new HttpClient())
//             {   
//                 // client.BaseAddress = new Uri("https://localhost:7276/databaseName???/api/Elevators/4");
//                 // client.BaseAddress = new Uri("https://localhost:7276/api/Elevators/4");
//                 client.BaseAddress = new Uri("https://heroku-rocketelevators-martinc.herokuapp.com/api/Elevators/4");
//                 //HTTP GET
//                 Console.WriteLine("------------------------");
//                 Console.WriteLine("------------------------");
//                 Console.WriteLine("------------------------");
//                 Console.WriteLine("------------------------");
//                 Console.WriteLine("------------------------");
//                 Console.WriteLine("------------------------");
//                 Console.WriteLine("------------------------");
//                 var responseTask = client.GetAsync("elevators");
//                 responseTask.Wait();

//                 var result = responseTask.Result;
//                 if (result.IsSuccessStatusCode)
//                 {

//                     var readTask = result.Content.ReadAsAsync<Elevator[]>();
//                     readTask.Wait();

//                     var elevators = readTask.Result;

//                     foreach (var elevator in elevators)
//                     {
//                         Console.WriteLine(elevator.Id);
//                         Console.WriteLine("------------------------");
//                         Console.WriteLine("------------------------");
//                         Console.WriteLine("------------------------");
//                         Console.WriteLine("------------------------");
//                         Console.WriteLine("------------------------");
//                         Console.WriteLine("------------------------");
//                         Console.WriteLine("------------------------");
//                     }
//                 }
//             }
//             Console.ReadLine();
//         }        
//     }
// }