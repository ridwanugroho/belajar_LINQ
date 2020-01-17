using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JsonParser
{
    public class Profile
    {
        [JsonPropertyName("full_name")]
        public string full_name{get; set;}
        [JsonPropertyName("birthday")]
        public DateTime Birthday{get; set;}
        [JsonPropertyName("phones")]
        public string[] Phones{get; set;}
    }

    public class Articles
    {
        [JsonPropertyName("id")]
        public int ID{get; set;}
        [JsonPropertyName("title")]
        public string Title{get; set;}
        [JsonPropertyName("published_at")]
        public DateTime published_at{get; set;}
    }

    public class User
    {
        [JsonPropertyName("id")]
        public int ID{get; set;}
        [JsonPropertyName("username")]
        public string Username{get; set;}
        [JsonPropertyName("profile")]
        public Profile Profile{get; set;}
        [JsonPropertyName("articles")]
        public List<Articles> articles{get; set;} = new List<Articles>();

    }
}