using Microsoft.AspNetCore.Mvc;
using MyClientAsp.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Security.Policy;

namespace MyClientAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult RestError()
        {
            return View();
        }

        public async Task<IActionResult> MyRestApi()
        {
            List<PersonModel> persons = new List<PersonModel>();

            var client = new HttpClient();

            await Task.Run(() =>
            {
                    var response = client.GetAsync("https://localhost:7099/api/Persons").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the response body
                        var dataObjects = response.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<List<PersonModel>>(dataObjects);

                        foreach (var item in result)
                        {
                            if (item != null)
                            {
                                //  MessageBox.Show(item.SchoolId.ToString());
                                persons.Add(item);


                            }

                        }
                    }
                    else
                    {
                        //  return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                        
                        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    }

            });
            return View(persons);

        }

        public async Task<IActionResult> Details(string id)
        {
            //ViewData["personID"] = id;
            var client = new HttpClient();
            var person = new PersonModel();

             await Task.Run(() =>
             {
                 var response = client.GetAsync("https://localhost:7099/api/Persons/id?id="+id).Result;

                 if (response.IsSuccessStatusCode)
                 {
                     // Parse the response body
                     var dataObjects = response.Content.ReadAsStringAsync().Result;
                     person = JsonConvert.DeserializeObject<PersonModel>(dataObjects);
                     Console.WriteLine("ok");
                 }
                 else
                 {
                     //  return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

                     Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                 }

             });
            return View(person);
        }

        public async Task<IActionResult> Create(PersonModel person)
        {
            person.PersonId = Guid.NewGuid().ToString();

            using var client = new HttpClient();
            string json = JsonConvert.SerializeObject(person);   //using Newtonsoft.Json

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");


            var response = await client.PostAsync("https://localhost:7099/api/Persons", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data Posted");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode,
                              response.ReasonPhrase);
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var client = new HttpClient();
            var person = new PersonModel();

            await Task.Run(() =>
            {
                var response = client.GetAsync("https://localhost:7099/api/Persons/id?id=" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    person = JsonConvert.DeserializeObject<PersonModel>(dataObjects);
                    Console.WriteLine("ok");
                }
                else
                {
                    //  return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

            });
            return View(person);
        }

        public async Task<IActionResult> DeletedRecord(string id)
        {
            ViewData["personID"] = id;
            Console.WriteLine(id);

            var person = new PersonModel();

            var client = new HttpClient();

           
            await Task.Run(() =>
            {
                client.DeleteAsync("https://localhost:7099/api/Persons/id?id=" + id);
            });

            return View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            //ViewData["personID"] = id;
            var client = new HttpClient();
            var person = new PersonModel();

            await Task.Run(() =>
            {
                var response = client.GetAsync("https://localhost:7099/api/Persons/id?id=" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    person = JsonConvert.DeserializeObject<PersonModel>(dataObjects);
                    Console.WriteLine("ok");
                }
                else
                {
                    //  return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }

            });
            return View(person);
        }

        public async Task<IActionResult> UpdatedRecord(PersonModel person)
        {
            string? id = person.PersonId;

            ViewData["personID"] = id;

            Console.WriteLine(id);
          //  var person = new PersonModel();

            using var client = new HttpClient();

            string json = JsonConvert.SerializeObject(person);   //using Newtonsoft.Json

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");


            var response = await client.PutAsync("https://localhost:7099/api/Persons/id?id=" + id, httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data updated");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode,
                              response.ReasonPhrase);
            }

            return View();
        }



    }
}