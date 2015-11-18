using RestSharp;

namespace Scylla.Modules
{
    public class BaseModule
    {
        protected ScyllaJiraClient _client;

        public BaseModule(ScyllaJiraClient client)
        {
            this._client = client;
        }

        protected RestRequest Request(string resource, Method method, object data)
        {
            var request = new RestRequest();

            request.Resource = resource;
            request.Method = method;
            request.RequestFormat = DataFormat.Json;
            request.AddBody(data);

            return request;
        }
    }
}
