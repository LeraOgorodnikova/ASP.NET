using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.IO;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        [Import]
        public ILogger logger { get; set; }

        public ActionResult Index()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(".", "*.exe"));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);

            logger.Write("Hello");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}