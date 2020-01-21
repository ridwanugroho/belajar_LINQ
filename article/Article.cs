using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using JsonParser;

namespace ArticleManipulator
{
    /*
    public class Article
    {
        private List<User> items;

        public Article(string json)
        {
            items = JsonConvert.DeserializeObject<List<User>>(json);
        }
    
        public List<string> DontHvPhone()
        {
            var userFullName = new List<string>();
            foreach (var user in items)
            {
                if(user.Profile.Phones.Length == 0)
                    userFullName.Add(user.Profile.full_name);
            }

            return userFullName;
        }

        public List<string> HaveArticle()
        {
            var userFullName = new List<string>();
            foreach (var user in items)
            {
                if(user.articles.Count > 0)
                    userFullName.Add(user.Profile.full_name);
            }

            return userFullName;
        }
    
        public List<string> FindName(string name)
        {
            var userFullName = new List<string>();
            foreach (var user in items)
            {
                if(user.Profile.full_name.IndexOf("annis", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    userFullName.Add(user.Profile.full_name);
            }

            return userFullName;
        }

        public List<string> AuthorArticleOn(int year)
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
    
        public List<string> FindNameByBirthday(int year)
        {
            var userFullName = new List<string>();
            foreach (var user in items)
            {
                if(user.Profile.GetBornYear() == year)
                    userFullName.Add(user.Profile.full_name);
            }

            return userFullName;
        }
    
        public List<List<string>> FindArtContain(string find)
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

        public List<List<string>> FindArtPublishedBfr(string date)
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
*/
    public class LArticle
    {
        private List<User> items;

        public LArticle(string json)
        {
            items = JsonConvert.DeserializeObject<List<User>>(json);
        }

        public List<string> DontHvPhone()
        {         
            return items.Where(p => p.Profile.Phones.Length == 0)
                    .Select(p => p.Profile.full_name).ToList();
        }

        public List<string> HaveArticle()
        {
            return items.Where(a => a.articles.Count > 0)
                    .Select(n => n.Profile.full_name).ToList();
        }
    
        public List<string> FindName(string name)
        {
            return items.Where(n => n.Profile.full_name.IndexOf(name, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                        .Select(n => n.Profile.full_name).ToList();
        }

        public List<string> AuthorArticleOn(int year)
        {
            var ret = from i in items from y in i.articles where(y.GetArticleYear() == year) select y.Title;
            return ret.ToList();
        }
    
        public List<string> FindNameByBirthday(int year)
        {
            var ret = from i in items where(i.Profile.GetBornYear() == year) select i.Profile.full_name;
            return ret.ToList();
        }
    
        public List<List<string>> FindArtContain(string find)
        {
            var articles = new List<List<string>>();
            var ret = from i in items from a in i.articles where(a.Title.IndexOf(find, 0, StringComparison.CurrentCultureIgnoreCase) != -1) 
                        select new {a.Title, i.Profile.full_name};
            
            foreach (var item in ret)
                articles.Add(new List<string> {item.Title, item.full_name});

            return articles;
        }

        public List<List<string>> FindArtPublishedBfr(string date)
        {
            DateTime th = DateTime.Parse(date);
            var articles = new List<List<string>>();

            var ret = from i in items from a in i.articles where(a.published_at < th) 
                        select new {a.Title, i.Profile.full_name};
            
            foreach (var item in ret)
                articles.Add(new List<string> {item.Title, item.full_name});

            return articles;
        }
    
    }
}