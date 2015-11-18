using RestSharp;
using Scylla.Models;

namespace Scylla.Modules
{
    public class IssuesModule : BaseModule
    {
        public IssuesModule(ScyllaJiraClient client) : base (client)
        {
        }

        public Issue GetIssueByKey(string key, string fields = null, string expand = "")
        {
            var request = new RestRequest(string.Format("issue/{0}", key));

            if (fields != null)
                request.AddParameter("fields", fields);

            if (expand != null)
                request.AddParameter("expand", expand);

            return _client.Execute<Issue>(request);
        }

        public Issue GetIssueById(int id, string fields = null, string expand = "")
        {
            return GetIssueByKey(id.ToString(), fields, expand);
        }

        public CreateIssueResponse CreateIssue(string projectkey, string summary, string description)
        {
            CreateIssuePost issue = new CreateIssuePost();

            issue.fields.project.key = projectkey;
            issue.fields.summary = summary;
            issue.fields.description = description;
            issue.fields.issuetype.name = "Task";

            var request = this.Request("issue", RestSharp.Method.POST, issue);

            return _client.Execute<CreateIssueResponse>(request);
        }
    }
}
