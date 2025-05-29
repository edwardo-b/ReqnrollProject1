using ReqnrollProject1.API.Models;
using RestSharp;
using System.Text.Json;

namespace ReqnrollProject1.Utils
{
    internal class PetStoreApiUtils
    {
        private readonly ApiUtils _apiUtils;
        private static readonly string GetEndpoint = "pet/";
        private static readonly string PostEndpoint = "pet/";

        public PetStoreApiUtils(ApiUtils apiUtils)
        {
            _apiUtils = apiUtils;
        }

        public Pet GetPetById(long id)
        {
            return DeserializePetResponse(_apiUtils.SendGetRequest(GetEndpoint + id));
        }

        public RestResponse PostPet(Pet pet)
        {
            return _apiUtils.SendPostRequest(PostEndpoint, pet);
        }

        public bool PostPetIsSuccessful(Pet pet)
        {
            var response = _apiUtils.SendPostRequest(PostEndpoint, pet);
            var petResult = DeserializePetResponse(response);
            return response.IsSuccessful && petResult?.Id > 0;
        }

        public bool PutPetIsSuccessful(Pet pet)
        {
            var response = _apiUtils.SendPutRequest(PostEndpoint, pet);
            var petResult = DeserializePetResponse(response);
            return response.IsSuccessful && petResult?.Id == pet.Id;
        }

        public void DeletePetById(string id)
        {
            _apiUtils.SendDeleteRequest(PostEndpoint + id);
        }

        public RestResponse PutPetById(Pet pet)
        {
            return _apiUtils.SendPutRequest(PostEndpoint, pet);
        }

        private static Pet DeserializePetResponse(RestResponse petResponse)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<Pet>(petResponse.Content!, options)!;
        }
    }
}
