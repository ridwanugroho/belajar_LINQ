using System;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json;
using PurchaseParser;

namespace PurchaseController
{
    public class Purchase
    {
        private List<Order> orders;

        public Purchase(string json)
        {
            orders = JsonConvert.DeserializeObject<List<Order>>(json);
        }

        public void prcMade(string month)
        {
            var ci = new CultureInfo("id-ID");
            int dt = DateTime.ParseExact(month, "MMMM", ci).Month;
            foreach (var order in orders)
            {
                if(order.created_at.Month == dt)
                    Console.WriteLine("{0} : {1}", order.order_id, order.customer.name);
            }
        }

        public double calculateTotal(Order order)
        {
            double total = 0;
            foreach (var item in order.items)
                total += item.qty * item.price;

            return total;
        }

        public double prcMadeBy(string name)
        {
            double total = 0;
            foreach (var order in orders)
            {
                if(order.customer.name.IndexOf(name, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                {
                    total += calculateTotal(order);
                }
            }

            return total;
        }

        public List<string> grandTotLower(double price)
        {
            var ret = new List<string>();
            foreach (var order in orders)
            {
                if(calculateTotal(order) < price && !ret.Contains(order.customer.name))
                    ret.Add(order.customer.name);
            }

            return ret;
        }
    }
}