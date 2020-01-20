using System;
using System.IO;
using InventorController;

namespace inv
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader("inv.json");
            string json = r.ReadToEnd();
            InventoryController inv = new InventoryController(json);

            separator("item in Sngkuriang room");
            Console.WriteLine("total item : {0}", inv.ItemInRoom("Sangkuriang"));

            separator("all electronic devices");
            foreach (var item in inv.AllDevInType("electronic"))
                Console.WriteLine(item);

            separator("all furnitures");
            foreach (var item in inv.AllDevInType("furniture"))
                Console.WriteLine(item);

            separator("item purchased at 16 januari 2020");
            foreach (var item in inv.ItemPurchasedAt("16 Januari 2020"))
                Console.WriteLine(item);

            separator("item brown colored");
            foreach (var item in inv.LisItemByColor("brown"))
                Console.WriteLine(item);
        }

        static void separator( string info)
        {
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine(info);
        }
    }
}
