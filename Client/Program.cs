using RestSharp;
using Scylla.Models;
using System;

namespace Scylla
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ScyllaJiraClient client = new ScyllaJiraClient("username", "password");

                // List project ids and keys...
                client.Projects.GetProjects().ForEach(proj => { Console.WriteLine(string.Format("{0}-{1}", proj.id, proj.key)); });

                // TYPED - Grab an issue
                Issue issue = client.Issues.GetIssueByKey("BAE-15");

                // JSON - Grab an issue
                IRestResponse issue2 = client.Execute(new RestRequest("issue/BAE-15"));
                string json = issue2.Content;

                // Create issue
                CreateIssueResponse issue3 = client.Issues.CreateIssue("AT", "First Issue", "Description of the issue...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
