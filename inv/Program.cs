using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using InvParser;

namespace inv
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader("inv.json");
            string json = r.ReadToEnd();

            List<Inventory> invents = JsonConvert.DeserializeObject<List<Inventory>>(json);

            separator("item in Sngkuriang room");
            Console.WriteLine("total item : {0}", ItemInRoom(invents, "Sangkuriang"));

            separator("all electronic devices");
            foreach (var item in AllDevInType(invents, "electronic"))
                Console.WriteLine(item);

            separator("all furnitures");
            foreach (var item in AllDevInType(invents, "furniture"))
                Console.WriteLine(item);

            separator("item purchased at 16 januari 2020");
            foreach (var item in ItemPurchasedAt(invents, "16 Januari 2020"))
                Console.WriteLine(item);

            separator("item brown colored");
            foreach (var item in LisItemByColor(invents, "brown"))
                Console.WriteLine(item);
        }
        

        static void separator( string info)
        {
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine(info);
        }

        static int ItemInRoom(List<Inventory> inventory, string room)
        {
            int totalItem = 0;
            foreach (var item in inventory)
            {
                if(item.placement.name == room)
                    totalItem++;
            }

            return totalItem;
        }

        static List<string> AllDevInType(List<Inventory> inventory, string type)
        {
            var device = new List<string>();
            foreach (var item in inventory)
            {
                if(item.type.IndexOf(type, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    device.Add(item.name);
            }

            return device;
        }
    
        static List<string> ItemPurchasedAt(List<Inventory> inventory, string date)
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
    
        static List<string> LisItemByColor(List<Inventory> inventory, string color)
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
}
