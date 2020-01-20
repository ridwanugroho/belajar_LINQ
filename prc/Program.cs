using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using PurchaseParser;

namespace prc
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader("prc.json");
            string json = r.ReadToEnd();

            List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(json);

            separator("order made in february : ");
            prcMadeFeb(orders);

            separator("All purchases made by Ari, and the grand total :");
            Console.WriteLine("Rp {0}", prcMadeByAri(orders));

            separator("customers who have order < 300000");
            foreach (var l in grandTotLow(orders))
            {
                Console.WriteLine(l);
            }
        }


        static void separator( string info)
        {
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine(info);
        }

        static void prcMadeFeb(List<Order> orders)
        {
            foreach (var order in orders)
            {
                if(order.created_at.Month == 2)
                    Console.WriteLine("{0} : {1}", order.order_id, order.customer.name);
            }
        }

        static double calculateTotal(Order order)
        {
            double total = 0;
            foreach (var item in order.items)
                total += item.qty * item.price;

            return total;
        }

        static double prcMadeByAri(List<Order> orders)
        {
            double total = 0;
            foreach (var order in orders)
            {
                if(order.customer.name.IndexOf("Ari", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                {
                    total += calculateTotal(order);
                }
            }

            return total;
        }

        static List<string> grandTotLow(List<Order> orders)
        {
            var ret = new List<string>();
            foreach (var order in orders)
            {
                if(calculateTotal(order) < 300000 && !ret.Contains(order.customer.name))
                    ret.Add(order.customer.name);
            }

            return ret;
        }
    }
}
