using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MidiumApi.Models
{
    public class Article
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime datePublished { get; set; }
        public string imageUrl { get; set; }
    }
}