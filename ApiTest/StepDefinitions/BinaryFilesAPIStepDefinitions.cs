using ApiTest.Utils;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json.Linq;
using Reqnroll;
using Reqnroll.BoDi;
using RestSharp;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ApiTest.StepDefinitions
{
    [Binding]
    public class BinaryFilesAPIStepDefinitions
    {
        private readonly BinaryFilesApiUtils _binaryFilesApiUtils;
        private RestResponse _response;
        private readonly ITestOutputHelper _output;
        public BinaryFilesAPIStepDefinitions(IObjectContainer container,ITestOutputHelper output)
        {

            _binaryFilesApiUtils = container.Resolve<BinaryFilesApiUtils>();
            _response = new RestResponse();
            _output = output;
        }

        [When("I send a GET request to {string}")]
        public async Task WhenISendAGETRequestTo(string endpoint)
        {
            var (response, uri) = await _binaryFilesApiUtils.GetAllBinaryFilesAsync();
            _response = response;

            _output.WriteLine($"[DEBUG] Sent GET request to: {uri}");
            _output.WriteLine($"[DEBUG] Response content: {_response.Content}");
        }

        [Then("the response status code should be {int}")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            Assert.NotNull(_response);
            Assert.Equal(expectedStatusCode, (int)_response.StatusCode);
        }

        [Then("the response {string} property should be an array")]
        public void ThenTheResponsePropertyShouldBeAnArray(string propertyName)
        {
            var body = JObject.Parse(_response.Content!);
            Assert.True(body[propertyName] is JArray, $"Property '{propertyName}' is not an array.");
        }

        [Then("the first item's {string} property should be {string}")]
        public void ThenTheFirstItemsPropertyShouldBe(string propertyName, string expectedValue)
        {
            var body = JObject.Parse(_response.Content!);
            var array = body["value"] as JArray;

            Assert.NotNull(array);
            Assert.True(array.Count > 0, "Array 'value' is empty.");
            var firstItem = array[0];

            Assert.Equal(expectedValue, firstItem[propertyName]?.ToString());
        }
    }
}
