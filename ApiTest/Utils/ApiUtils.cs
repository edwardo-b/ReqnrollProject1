using Newtonsoft.Json;
using Reqnroll.BoDi;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTest.Utils
{
    internal class ApiUtils
    {
        private readonly RestClient _client;

        public ApiUtils(IObjectContainer container)
        {
            _client = container.Resolve<RestClient>();
        }

        public async Task<(RestResponse response, Uri requestUri)> SendGetRequestWithUriAsync(string endpoint, Dictionary<string, string>? headers = null)
        {
            var request = new RestRequest(endpoint, Method.Get);
            AddHeaders(request, headers);
            var fullUri = _client.BuildUri(request);
            var response = await _client.ExecuteAsync(request);
            return (response, fullUri);
        }

        public async Task<(RestResponse response, Uri requestUri)> SendPostRequestWithUriAsync(string endpoint, object body, Dictionary<string, string>? headers = null)
        {
            var request = new RestRequest(endpoint, Method.Post);
            AddHeaders(request, headers);
            request.AddJsonBody(body);
            var fullUri = _client.BuildUri(request);
            var response = await _client.ExecuteAsync(request);
            return (response, fullUri);
        }

        public async Task<(RestResponse response, Uri requestUri)> SendPutRequestWithUriAsync(string endpoint, object body, Dictionary<string, string>? headers = null)
        {
            var request = new RestRequest(endpoint, Method.Put);
            AddHeaders(request, headers);
            request.AddJsonBody(body);
            var fullUri = _client.BuildUri(request);
            var response = await _client.ExecuteAsync(request);
            return (response, fullUri);
        }

        public async Task<(RestResponse response, Uri requestUri)> SendDeleteRequestWithUriAsync(string endpoint, Dictionary<string, string>? headers = null)
        {
            var request = new RestRequest(endpoint, Method.Delete);
            AddHeaders(request, headers);
            var fullUri = _client.BuildUri(request);
            var response = await _client.ExecuteAsync(request);
            return (response, fullUri);
        }

        public static T? DeserializeResponse<T>(RestResponse response)
        {
            if (string.IsNullOrWhiteSpace(response.Content))
                return default;
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        private static void AddHeaders(RestRequest request, Dictionary<string, string>? headers)
        {
            if (headers == null) return;
            foreach (var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }
        }
    }
}
