//soal ::::: https://gist.github.com/mul14/af01c604fe3ba809187e4267e7f3afd4

using System;
using System.IO;
using ArticleManipulator;


namespace article
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader("data.json");
            string json = r.ReadToEnd();
            Article article = new Article(json);
            
            separator("Users who does not have phone number : ");
            foreach (var user in article.DontHvPhone())
                Console.WriteLine(user);

            separator("Users who have articles : ");
            foreach (var user in article.HaveArticle())
                Console.WriteLine(user);

            separator("Users who have \"annis\": ");
            foreach (var user in article.FindName("annis"))
                Console.WriteLine(user);

            separator("Users who have article on 2020");
            foreach (var user in article.AuthorArticleOn(2020))
                Console.WriteLine(user);
            
            separator("Users who are born on 1986");
            foreach (var user in article.FindNameByBirthday(1986))
                Console.WriteLine(user);

            separator("Article that contain \"tips\" on the title: ");
            foreach (var item in article.FindArtContain("tips"))
                Console.WriteLine("{0} : {1}", item[0], item[1]);

            separator("Article published before August 2019: ");
            DateTime th = DateTime.Parse("August 2019");
            foreach (var item in article.FindArtPublishedBfr("August 2019"))
                Console.WriteLine("{0} : {1}", item[0], item[1]);

            separator("~~~~~~~~~~~~~~~~~~~END~~~~~~~~~~~~~~~~~~~~");
        }

        static void separator( string info)
        {
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine(info);
        }
    }
    
}
