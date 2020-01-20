using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PurchaseParser
{
    public class Order
    {
        public string order_id{get; set;}
        public DateTime created_at{get; set;}
        public Customer customer{get; set;}
        public List<Item> items{get; set;} = new List<Item>();
    }

    public class Customer
    {
        public int id{get; set;}
        public string name{get; set;}
    }

    public class Item
    {
        public int id{get; set;}
        public string name{get; set;}
        public int qty{get; set;}
        public double price{get; set;}
    }
    
}