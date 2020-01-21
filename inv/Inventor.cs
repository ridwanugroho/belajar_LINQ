using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using InvParser;

namespace InventorController
{
    /*
    public class InventoryController
    {
        private List<Inventory> inventory;
        
        public InventoryController(string json)
        {
            inventory = JsonConvert.DeserializeObject<List<Inventory>>(json);
        }

        public int ItemInRoom(string room)
        {
            int totalItem = 0;
            foreach (var item in inventory)
            {
                if(item.placement.name == room)
                    totalItem++;
            }

            return totalItem;
        }

        public List<string> AllDevInType(string type)
        {
            var device = new List<string>();
            foreach (var item in inventory)
            {
                if(item.type.IndexOf(type, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    device.Add(item.name);
            }

            return device;
        }
    
        public List<string> ItemPurchasedAt(string date)
        {
            var ci = new CultureInfo("id-ID");
            DateTime dt = DateTime.Parse(date, ci);
            List<string> items = new List<string>();

            foreach (var item in inventory)
            {
                if(item.getPurchaseDate().Date == dt)
                    items.Add(item.name);
            }

            return items;
        }
    
        public List<string> LisItemByColor(string color)
        {
            var device = new List<string>();
            foreach (var item in inventory)
            {
                foreach (var tag in item.tags)
                {
                    if(tag.IndexOf(color, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        device.Add(item.name);
                        break;
                    }
                }
            }

            return device;
        }
    }
*/

    public class LInventoryController
    {
        private List<Inventory> inventory;
        
        public LInventoryController(string json)
        {
            inventory = JsonConvert.DeserializeObject<List<Inventory>>(json);
        }

        public int ItemInRoom(string room)
        {
            var ret = from item in inventory where(item.placement.name == room) select item.name;
            return ret.Count();
        }

        public List<string> AllDevInType(string type)
        {
            var ret = from item in inventory where(item.type.IndexOf(type, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    select item.name;
            return ret.ToList();
        }
    
        public List<string> ItemPurchasedAt(string date)
        {
            var ci = new CultureInfo("id-ID");
            DateTime dt = DateTime.Parse(date, ci);
            var ret = from item in inventory where(item.getPurchaseDate().Date == dt)
                        select item.name;

            return ret.ToList();
        }
    
        public List<string> LisItemByColor(string color)
        {
            var ret = from item in inventory from clr in item.tags where(clr.IndexOf(color, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                        select item.name;

            return ret.ToList();
        }
    }
}