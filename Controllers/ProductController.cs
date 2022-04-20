using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;


namespace HttpClientDemo
{   
    
    
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                // client.BaseAddress = new Uri("http://localhost:7276/api/Elevators/1");
                client.BaseAddress = new Uri("https://heroku-rocketelevators-martinc.herokuapp.com/api/Elevators/1");
                //HTTP GET
                var responseTask = client.GetAsync("elevators");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<elevators[]>();
                    readTask.Wait();

                    var elevators = readTask.Result;

                    foreach (var elevator in elevators)
                    {
                        Console.WriteLine(elevator.Name);
                    }
                }
            }
            Console.ReadLine();
        }        
    }
}