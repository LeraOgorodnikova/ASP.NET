using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplicationNetCore_v2.Models;

namespace WebApplicationNetCore_v2.Controllers
{
    public class ItemDescription : Controller
    {
        [ResponseCache(Duration = 60)]
        public IActionResult Index(int id)
        {
            Item item = ItemReader.GetItemById(id);
            return View(item);
        }
    }
}
