using ApiTest.Utils;
using Reqnroll;
using Reqnroll.BoDi;
using ReqnrollProject1.Utils;
using RestSharp;
using System.Threading.Tasks;

namespace ApiTest.Hook
{
    [Binding]
    public sealed class Hooks
    {
        public readonly ScenarioContext _scenarioContext;
        public readonly IObjectContainer _objectContainer;
        private readonly RestClient _client;

        private static readonly string[] IgnoreDefaultArgsArray = { "--enable-automation" }; // Fix for CA1861

        public Hooks(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
            _client = new RestClient();
        }
        // For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks

        [BeforeScenario("@API")]
        public void BeforeAPIScenario()
        {
            var baseUrl = ConfigReader.GetConfigAppSettingValue("Urls:baseRequestUrl");
            var client = new RestClient(baseUrl);
            _objectContainer.RegisterInstanceAs(client);

            var apiUtils = new ApiUtils(_objectContainer);
            _objectContainer.RegisterInstanceAs(apiUtils);

            var binaryFilesApiUtils = new BinaryFilesApiUtils(apiUtils);
            _objectContainer.RegisterInstanceAs(binaryFilesApiUtils);
        }

        [AfterScenario("@API")]
        public void AfterAPIScenario()
        {
            if (_scenarioContext.TryGetValue("deleteResource", out var resourceObj) && resourceObj is string resource)
            {
                var apiUtils = _objectContainer.Resolve<ApiUtils>();
                apiUtils.SendDeleteRequestWithUriAsync(resource);
            }
        }

    }
}