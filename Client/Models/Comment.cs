using System;

namespace Scylla.Models
{
    public class Comment
    {
        public int id { get; set; }
        public string self { get; set; }
        public Author author { get; set; }
        public string body { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
    }
}
