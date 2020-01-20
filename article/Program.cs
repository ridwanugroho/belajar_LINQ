//soal ::::: https://gist.github.com/mul14/af01c604fe3ba809187e4267e7f3afd4

using System;
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
            StreamReader r = new StreamReader("data.json");
            string json = r.ReadToEnd();

            List<User> items = JsonConvert.DeserializeObject<List<User>>(json);
            
            separator("Users who does not have phone number : ");
            foreach (var user in DontHvPhone(items))
                Console.WriteLine(user);

            separator("Users who have articles : ");
            foreach (var user in HaveArticle(items))
                Console.WriteLine(user);

            separator("Users who have \"annis\": ");
            foreach (var user in FindName(items, "annis"))
                Console.WriteLine(user);

            separator("Users who have article on 2020");
            foreach (var user in AuthorArticleOn(items, 2020))
                Console.WriteLine(user);
            
            separator("Users who are born on 1986");
            foreach (var user in FindNameByBirthday(items, 1986))
                Console.WriteLine(user);

            separator("Article that contain \"tips\" on the title: ");
            foreach (var item in FindArtContain(items, "tips"))
                Console.WriteLine("{0} : {1}", item[0], item[1]);

            separator("Article published before August 2019: ");
            DateTime th = DateTime.Parse("August 2019");
            foreach (var item in FindArtPublishedBfr(items, "August 2019"))
                Console.WriteLine("{0} : {1}", item[0], item[1]);

            separator("~~~~~~~~~~~~~~~~~~~END~~~~~~~~~~~~~~~~~~~~");
        }


        static void separator( string info)
        {
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine(info);
        }
    
        static List<string> DontHvPhone(List<User> items)
        {
            var userFullName = new List<string>();
            foreach (var user in items)
            {
                if(user.Profile.Phones.Length == 0)
                    userFullName.Add(user.Profile.full_name);
            }

            return userFullName;
        }

        static List<string> HaveArticle(List<User> items)
        {
            var userFullName = new List<string>();
            foreach (var user in items)
            {
                if(user.articles.Count > 0)
                    userFullName.Add(user.Profile.full_name);
            }

            return userFullName;
        }
    
        static List<string> FindName(List<User> items, string name)
        {
            var userFullName = new List<string>();
            foreach (var user in items)
            {
                if(user.Profile.full_name.IndexOf("annis", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    userFullName.Add(user.Profile.full_name);
            }

            return userFullName;
        }

        static List<string> AuthorArticleOn(List<User> items, int year)
        {
            var userFullName = new List<string>();
            foreach (var user in items)
            {
                foreach (var art in user.articles)
                {
                    if(art.GetArticleYear() == year && !userFullName.Contains(user.Profile.full_name))
                    {
                        userFullName.Add(user.Profile.full_name);
                        break;
                    }
                }
            }

            return userFullName;
        }
    
        static List<string> FindNameByBirthday(List<User> items, int year)
        {
            var userFullName = new List<string>();
            foreach (var user in items)
            {
                if(user.Profile.GetBornYear() == year)
                    userFullName.Add(user.Profile.full_name);
            }

            return userFullName;
        }
    
        static List<List<string>> FindArtContain(List<User> items, string find)
        {
            var articles = new List<List<string>>();

            foreach (var user in items)
            {
                foreach (var art in user.articles)
                {
                    if(art.Title.IndexOf(find, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                        articles.Add(new List<string> {art.Title, user.Profile.full_name});
                }
            }

            return articles;
        }

        static List<List<string>> FindArtPublishedBfr(List<User> items, string date)
        {
            DateTime th = DateTime.Parse(date);
            var articles = new List<List<string>>();

            foreach (var user in items)
            {
                foreach (var art in user.articles)
                {
                    if(art.published_at < th)
                        articles.Add(new List<string> {art.Title, user.Profile.full_name});
                }
            }

            return articles;
        }
    }
    
}
