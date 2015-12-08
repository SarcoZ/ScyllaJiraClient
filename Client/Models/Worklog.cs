using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scylla.Models
{
    public class WorkLogResponse
    {
        public int total { get; set; }
        public List<WorkLog> worklogs { get; set; }
        
        public WorkLogResponse()
        {
            worklogs = new List<WorkLog>();
        }
    }

    public class WorkLog
    {
        public string self { get; set; }
        public string comment { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public DateTime started { get; set; }
        public string timeSpent { get; set; }
        public int timeSpentSeconds { get; set; }
        public string id { get; set; }
        public Author author { get; set; }
        public Author updateAuthor { get; set; }
    }
}
