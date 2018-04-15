using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplicationNetCore_v2.Models;

namespace WebApplicationNetCore_v2.Controllers
{
    public class HomeController : Controller
    {

        [ResponseCache(Duration = 60)] 
        public IActionResult Index()
        {
            Dictionary<int, Item> items = ItemReader.GetItems();
            return View(items.Values.ToList());
            /*using (StreamReader r = new StreamReader("items.json", Encoding.Default))
            {
                string json = r.ReadToEnd();
                JObject obj = JObject.Parse(json);
                JArray array = (JArray)obj["products"];
                List<Item> items = array.ToObject<List<Item>>();
            }

            return View();*/
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
