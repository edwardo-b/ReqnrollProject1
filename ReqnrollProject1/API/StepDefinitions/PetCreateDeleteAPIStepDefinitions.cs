using NUnit.Framework;
using Reqnroll.BoDi;
using ReqnrollProject1.API.Models;
using ReqnrollProject1.Utils;
using RestSharp;
using System.ComponentModel;

namespace ReqnrollProject1.API.StepDefinitions
{
    [Binding]
    public class PetCreateDeleteAPIStepDefinitions
    {
        private RestResponse _response;
        private readonly ScenarioContext _scenarioContext;
        private readonly PetStoreApiUtils _petStoreApi;

        public PetCreateDeleteAPIStepDefinitions(ScenarioContext scenarioContext, IObjectContainer container)
        {
            _scenarioContext = scenarioContext;
            _response = new RestResponse();

            _petStoreApi = container.Resolve<PetStoreApiUtils>();
        }

        [When("I create a pet using the API")]
        public void WhenICreateAPetUsingTheAPI()
        {
            var pet = new Pet(
                ConfigReader.GetNumericalTestDataValue("petId"),
                ConfigReader.GetTestDataValue("petName"),
                ConfigReader.GetTestDataValue("petStatus"));

            _response = _petStoreApi.PostPet(pet);

            //_scenarioContext["deleteResource"] = $"pet/{pet.Id}";
        }

        [Then("the pet should be created successfully")]
        public void ThenThePetShouldBeCreatedSuccessfully()
        {
            Assert.AreEqual(200, (int)_response.StatusCode);
        }
    }
}
