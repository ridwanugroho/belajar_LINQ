using System;
using System.IO;
using PurchaseController;

namespace prc
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader("prc.json");
            string json = r.ReadToEnd();
            LPurchase purchase = new LPurchase(json);

            separator("order made in february : ");
            foreach(var item in purchase.prcMade("februari"))
                Console.WriteLine("{0} : {1}", item[0], item[1]);

            separator("All purchases made by Ari, and the grand total :");
            Console.WriteLine("Rp {0}", purchase.prcMadeBy("ari"));

            separator("customers who have order < 300000");
            foreach (var l in purchase.grandTotLower(300000))
                Console.WriteLine(l);
        }


        static void separator( string info)
        {
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine(info);
        }
    }
}
