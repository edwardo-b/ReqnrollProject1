using Reqnroll.BoDi;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Utils
{
    internal class ApiUtils
    {
        //private static readonly RestClient client = new(ConfigReader.GetConfigAppSettingValue("baseRequestUrl"));
        private readonly RestClient client;

        public ApiUtils(IObjectContainer container)
        {
            client = container.Resolve<RestClient>();
        }
        public  RestResponse SendGetRequest(string resource)
        {
            //implement a simple get request
            var request = new RestRequest(resource,Method.Get);
            return client.Execute(request);
            //return null;
        }

        public  RestResponse SendPostRequest(string resource, Object body)
        {

            return client.Execute(new RestRequest(resource, Method.Post)
            { RequestFormat = DataFormat.Json }
                .AddBody(body));
        }
        public  RestResponse SendPutRequest(string resource, Object body)
        {

            return client.Execute(new RestRequest(resource, Method.Put)
            { RequestFormat = DataFormat.Json }
                .AddBody(body));
        }
        public  RestResponse SendDeleteRequest(string resource)
        {

            return client.Execute(new RestRequest(resource, Method.Delete)
            { RequestFormat = DataFormat.Json });
        }
    }
}
