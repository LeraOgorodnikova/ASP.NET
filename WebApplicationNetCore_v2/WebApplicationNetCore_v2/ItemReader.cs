using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNetCore_v2.Models;

namespace WebApplicationNetCore_v2
{
    public class ItemReader
    {

        public static Dictionary<int, Item> GetItems()
        {
            var json = File.ReadAllText("items.json");
            var items = JsonConvert.DeserializeObject<Dictionary<int,Item>>(json);
            return items;
        }

        public static Item GetItemById(int id)
        {
            var data = File.ReadAllText("items.json");
            Item item = JsonConvert.DeserializeObject<Dictionary<int, Item>>(data)[id];
            return item;
        }
    }
}
