
namespace Scylla.Models
{
    // FIXME: Figure out how to reuse the Issue class
    public class CreateIssuePost
    {
        public FieldsPost fields { get; set; }
        public CreateIssuePost()
        {
            fields = new FieldsPost();
        }
    }

    public class FieldsPost
    {
        public ProjectPost project { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public IssueTypePost issuetype { get; set; }
        public FieldsPost()
        {
            project = new ProjectPost();
            issuetype = new IssueTypePost();
        }
    }

    public class ProjectPost
    {
        public string key { get; set; }
    }

    public class IssueTypePost
    {
        public string name { get; set; }
    }
}
