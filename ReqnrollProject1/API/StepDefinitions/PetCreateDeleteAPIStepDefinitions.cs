using NUnit.Framework;
using ReqnrollProject1.API.Models;
using ReqnrollProject1.Utils;
using RestSharp;

namespace ReqnrollProject1.API.StepDefinitions
{
    [Binding]
    public class PetCreateDeleteAPIStepDefinitions
    {
        private RestResponse _response;
        private readonly ScenarioContext _scenarioContext;

        public PetCreateDeleteAPIStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _response = new RestResponse();
        }

        [When("I create a pet using the API")]
        public void WhenICreateAPetUsingTheAPI()
        {
            var pet = new Pet(
                ConfigReader.GetNumericalTestDataValue("petId"),
                ConfigReader.GetTestDataValue("petName"),
                ConfigReader.GetTestDataValue("petStatus"));

            _response = PetStoreApiUtils.PostPet(pet);

            _scenarioContext["deleteResource"] = $"pet/{pet.Id}";
        }

        [Then("the pet should be created successfully")]
        public void ThenThePetShouldBeCreatedSuccessfully()
        {
            Assert.AreEqual(200, (int)_response.StatusCode);
        }
    }
}
