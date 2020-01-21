using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InvParser
{
    public class Inventory
    {
        public int inventory_id{get; set;}
        public string name{get; set;}
        public string type{get; set;}
        public string[] tags{get; set;}
        public double purchased_at{get; set;}
        public Placement placement{get; set;}

        public DateTime getPurchaseDate()
        {
            DateTime dt = new DateTime(1970,1,1,0,0,0,0,DateTimeKind.Utc);
            dt = dt.AddSeconds(purchased_at).ToLocalTime();
            return dt;
        }

    }

    public class Placement
    {
        public int room_id{get; set;}
        public string name{get; set;}
    }
}