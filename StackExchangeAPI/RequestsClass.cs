using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using StackExchangeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace StackExchangeAPI
{
    public static class RequestsClass
    {
        public static async Task<StackOverFlowTagsList> PostToStackExchangeApi (int page)
        {

            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            HttpClient client = new HttpClient(handler);

            HttpResponseMessage response = await client.GetAsync("https://api.stackexchange.com/2.2/tags?page=" + page + "&pagesize=100&order=desc&sort=popular&site=stackoverflow");
            response.EnsureSuccessStatusCode();
            var contentFromResponse = await response.Content.ReadAsStringAsync();
            var datalist = JsonConvert.DeserializeObject<StackOverFlowTagsList>(contentFromResponse);
            return datalist;
        }
    }
}
