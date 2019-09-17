using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspcoreconsumingwebapi.Models;
using aspcoreconsumingwebapi.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace aspcoreconsumingwebapi.Controllers
{
    public class HomeController : Controller
    {
        ValuesAPI _api = new ValuesAPI();

        public async Task<IActionResult> Index()
        {
            string[] strings = new string[5];
            HttpClient client = _api.Initial();
            //HttpResponseMessage res = await client.GetAsync("api/Values");
            //if (res.IsSuccessStatusCode)
            //{
            //    var result = res.Content.ReadAsStringAsync().Result;
            //    strings = JsonConvert.DeserializeObject<string[]>(result);
            //}
            //return View(strings);

            client.BaseAddress = new Uri("http://172.30.209.13:8080");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/values/5");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                strings = JsonConvert.DeserializeObject<string[]>(result);
            }
            return View(strings);
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
}
