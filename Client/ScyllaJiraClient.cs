using RestSharp;
using RestSharp.Authenticators;
using Scylla.Modules;
using System;

namespace Scylla
{
    public class ScyllaJiraClient
    {
        public const string BaseURL = "https://jira.scyllagroup.com/rest/api/latest";

        public IssuesModule Issues { get { return _issues; } }
        public ProjectsModule Projects { get { return _projects; } }

        private IssuesModule _issues;
        private ProjectsModule _projects;
        private RestClient _client;

        public ScyllaJiraClient(string username, string password)
        {
            this._client = new RestClient(BaseURL);
            this._issues = new IssuesModule(this);
            this._projects = new ProjectsModule(this);

            if (username != "" && password != "")
                _client.Authenticator = new HttpBasicAuthenticator(username, password);
            else
                throw new Exception("Invalid Username/Password");
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var response = _client.Execute<T>(request);

            // TODO: Build out a JiraException class
            if ((response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Created) || response.Data == null)
                throw new Exception(response.Content);

            return response.Data;
        }

        public IRestResponse Execute(RestRequest request)
        {
            return _client.Execute(request);
        }
    }
}
