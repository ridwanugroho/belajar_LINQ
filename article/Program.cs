//soal ::::: https://gist.github.com/mul14/af01c604fe3ba809187e4267e7f3afd4

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using JsonParser;

namespace article
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader("data.json"))
            {
                string json = r.ReadToEnd();
                // Console.WriteLine(json);
                List<User> items = JsonConvert.DeserializeObject<List<User>>(json);

                Console.WriteLine("Users who does not have phone number : ");
                foreach (var user in items)
                {
                    if(user.Profile.Phones.Length == 0)
                        Console.WriteLine(user.Profile.full_name);
                }

                Console.WriteLine();
                Console.WriteLine("==========================================");
                Console.WriteLine("Users who does not have articles : ");
                foreach (var user in items)
                {
                    if(user.articles.Count > 0)
                        Console.WriteLine(user.Profile.full_name);
                }

                Console.WriteLine();
                Console.WriteLine("==========================================");
                Console.WriteLine("Users who does not have \"annis\": ");
                foreach (var user in items)
                {
                    if(user.Profile.full_name.Contains("Annis"))
                        Console.WriteLine(user.Profile.full_name);
                }



            }
        }
    }
    
}
