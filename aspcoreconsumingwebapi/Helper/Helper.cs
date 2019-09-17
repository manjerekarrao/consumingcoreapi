using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace aspcoreconsumingwebapi.Helper
{
    public class ValuesAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            //client.BaseAddress = new Uri("http://172.30.209.13:8080/");
            client.BaseAddress = new Uri("https://localhost:44328/");
            return client;
        }
    }
}
