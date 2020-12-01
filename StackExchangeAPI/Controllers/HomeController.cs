using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchangeAPI.Models;

namespace StackExchangeAPI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<StackOverFlowTag> TagsList = new List<StackOverFlowTag>();
            for(int page = 1; page<=10; page++)
            {
                TagsList.AddRange(RequestsClass.PostToStackExchangeApi(page).Result.Items);
            }
            int allUsagesOfTags = TagsList.Select(i => i.count).Sum();
            ViewBag.allUsagesOfTags = allUsagesOfTags;
            StackOverFlowTagsList FinalList = new StackOverFlowTagsList() { Items = TagsList };
            return View(FinalList);
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
