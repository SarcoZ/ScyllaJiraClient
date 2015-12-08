using System.Collections.Generic;

namespace Scylla.Models
{
    // FIXME: for JQL queries
    public class IssueResult
    {
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Issue> issues { get; set; }

        public IssueResult()
        {
            issues = new List<Issue>();
        }
    }

    public class Issue
    {
        public int id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public IssueFields fields { get; set; }

        // TODO: Keep adding what we need...

        public Issue()
        {
            this.fields = new IssueFields();
        }
    }

    public class IssueFields
    {
        public string description { get; set; }
        public string summary { get; set; }
        public Project project { get; set; }
        public IssueComment comment { get; set; }
        public IssueType issuetype { get; set; }
        public WorkLogResponse worklog { get; set; }

        public IssueFields()
        {
            this.project = new Project();
            this.comment = new IssueComment();
            this.issuetype = new IssueType();
            this.worklog = new WorkLogResponse();
        }
    }

    public class IssueType
    {
        public string self { get; set; }
        public int id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
    }

    public class IssueComment
    {
        public int total { get; set; }
        public List<Comment> comments { get; set; }

        public IssueComment()
        {
            this.comments = new List<Comment>();
        }
    }
}
