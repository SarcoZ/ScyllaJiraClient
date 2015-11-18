using RestSharp;
using Scylla.Models;
using System.Collections.Generic;

namespace Scylla.Modules
{
    public class ProjectsModule : BaseModule
    {
        public ProjectsModule(ScyllaJiraClient client) : base (client)
        {
        }

        public List<Project> GetProjects(string expand = null, int? recent = null)
        {
            var request = new RestRequest("project");

            if (expand != null)
                request.AddParameter("expand", expand);

            if (recent != null)
                request.AddParameter("recent", recent);

            return _client.Execute<List<Project>>(request);
        }
    }
}
