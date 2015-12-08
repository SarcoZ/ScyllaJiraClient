using RestSharp;
using Scylla.Models;
using System;
using System.Collections.Generic;

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
                //client.Projects.GetProjects().ForEach(proj => { Console.WriteLine(string.Format("{0}-{1}", proj.id, proj.key)); });

                // TYPED - Grab an issue
                //Issue issue = client.Issues.GetIssueByKey("SWS-31");

                // JSON - Grab an issue
                //IRestResponse issue2 = client.Execute(new RestRequest("issue/SWS-31/worklog"));
                //string json = issue2.Content;

                // Create issue
                //CreateIssueResponse issue3 = client.Issues.CreateIssue("AT", "First Issue", "Description of the issue...");

                // Get issues by project
                IssueResult result = client.Issues.GetIssuesByProject("SWS");

                // Find all worklog entries
                result.issues.ForEach(issue => {
                    WorkLogResponse resp = client.Issues.GetIssueWorklogs(issue.key);
                    if (resp.total > 0) 
                    {
                        Console.WriteLine(issue.key + " - " + issue.fields.summary);
                        resp.worklogs.ForEach(wl => {
                            Console.WriteLine("\t" + wl.author.displayName + " spent " + wl.timeSpent + " on " + wl.created.ToShortDateString());
                        });
                    }
                });
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
