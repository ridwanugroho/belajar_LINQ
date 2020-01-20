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
                    if(user.Profile.full_name.IndexOf("annis", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                        Console.WriteLine(user.Profile.full_name);
                }

                Console.WriteLine();
                Console.WriteLine("==========================================");
                Console.WriteLine("Users who have article on 2020");
                foreach (var user in items)
                {
                    foreach (var art in user.articles)
                    {
                        if(art.GetArticleYear() == 2019)
                        {
                            Console.WriteLine(user.Profile.full_name);
                            break;
                        }
                    }
                }
                
                Console.WriteLine();
                Console.WriteLine("==========================================");
                Console.WriteLine("Users who are born on 1986");
                foreach (var user in items)
                {
                    if(user.Profile.GetBornYear() == 1986)
                        Console.WriteLine(user.Profile.full_name);
                }

                Console.WriteLine();
                Console.WriteLine("==========================================");
                Console.WriteLine("Article that contain \"tips\" on the title: ");
                foreach (var user in items)
                {
                    foreach (var art in user.articles)
                    {
                        if(art.Title.IndexOf("tips", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                            Console.WriteLine("{0} , oleh : {1}", art.Title, user.Profile.full_name);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("==========================================");
                Console.WriteLine("Article published before August 2019: ");
                DateTime th = DateTime.Parse("August 2019");
                foreach (var user in items)
                {
                    foreach (var art in user.articles)
                    {
                        if(art.published_at < th)
                            Console.WriteLine("{0} , oleh : {1}", art.Title, user.Profile.full_name);
                    }
                }
            }
        }
    }
    
}
