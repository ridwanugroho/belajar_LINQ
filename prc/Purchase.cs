using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json;
using PurchaseParser;

namespace PurchaseController
{
    /*
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
*/
    public class LPurchase
    {
        private List<Order> orders;

        public LPurchase(string json)
        {
            orders = JsonConvert.DeserializeObject<List<Order>>(json);
        }

        public List<List<string>> prcMade(string month)
        {
            var returnOrder = new List<List<string>>(); 
            var ci = new CultureInfo("id-ID");
            int dt = DateTime.ParseExact(month, "MMMM", ci).Month;

            var ret = from order in orders where(order.created_at.Month == dt)
                        select new {order.order_id, order.customer.name};
            foreach (var order in ret)
                returnOrder.Add(new List<string>{order.order_id, order.name});

            return returnOrder;
        }

        public double calculateTotal(Order order)
        {
            var ret = from item in order.items select item.qty*item.price;
            return ret.Sum();
        }

        public double prcMadeBy(string name)
        {
            var ret = from order in orders where(order.customer.name.IndexOf(name, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                        select calculateTotal(order);
            return ret.Sum();
        }

        public IEnumerable<string> grandTotLower(double price)
        {
            var ret = from order in orders where(calculateTotal(order) < price)
                        select order.customer.name;
            
            List<string> listName = ret.ToList();
            return listName.Distinct();
        }
    }
}