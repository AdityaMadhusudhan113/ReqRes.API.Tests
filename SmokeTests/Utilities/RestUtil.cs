using Newtonsoft.Json;
using RestSharp;
using SmokeTests.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTests.Utilities
{
    public  class RestUtil
    {

        public  RestResponse response; 
        EnvConfig config;
        public  string requestUrl = "";
        public RestClient client;
        public Object requestBody;

        public RestUtil()
        {
            config = new EnvConfig();
            client = new RestClient(config.BASE_URL);
        }
        public RestClient SetUrl(string baseUrl, string resourceUrl)
        {
            requestUrl = baseUrl + resourceUrl;
            client = new RestClient(requestUrl);
            return client;
        }

        public  RestResponse GetRequest(string param =null)
        {
            requestUrl += param;
            response = client.ExecuteGetAsync(createRequest(requestUrl, Method.Get)).Result;
            return response;

        }

        public  RestResponse PostRequest()
        {

            response = client.ExecutePostAsync(createRequest(requestUrl, Method.Post).AddJsonBody(requestBody)).Result;
            
            return response;

        }

      
        public  RestResponse DeleteRequest(string param )
        {
            requestUrl += param;        
            response = client.ExecuteAsync(createRequest(requestUrl,Method.Delete)).Result;
            return response;

        }

        public  RestResponse PutRequest(String param,Table requestBody)
        {
            requestUrl += param;
            response = client.ExecutePutAsync(createRequest(requestUrl, Method.Put).AddBody(requestBody)).Result;
            return response;

        }

        private  RestRequest createRequest(String url,Method method)
        {
            RestRequest resRequest = new RestRequest(requestUrl, method);

            resRequest.AddHeaders(new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" }

            });
            
      
            return resRequest;
        }
    }
}
