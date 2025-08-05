using ApiTest.Resources.Model;
using RestSharp;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiTest.Utils
{
    internal class BinaryFilesApiUtils
    {
        private readonly ApiUtils _apiUtils;

       
        private const string Endpoint = "/binaryfiles";

        public BinaryFilesApiUtils(ApiUtils apiUtils)
        {
            _apiUtils = apiUtils;
        }

        public async Task<(RestResponse response, Uri uri)> GetAllBinaryFilesAsync()
        {
            return await _apiUtils.SendGetRequestWithUriAsync(Endpoint);
        }


        public async Task<(RestResponse response, Uri uri)> PostBinaryFileAsync(BinaryFile binaryFile)
        {
            return await _apiUtils.SendPostRequestWithUriAsync(Endpoint, binaryFile);
        }

      
        public async Task<bool> IsPostSuccessfulAsync(BinaryFile binaryFile)
        {
            var (response, _) = await PostBinaryFileAsync(binaryFile);
            var result = DeserializeResponse(response);
            return response.IsSuccessful && result?.Id > 0;
        }


        /// <summary>
        /// Deserializes the response into a BinaryFile model.
        /// </summary>
        public static BinaryFile? DeserializeResponse(RestResponse response)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<BinaryFile>(response.Content!, options);
        }
    }
}
