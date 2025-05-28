using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ReqnrollProject1.Utils
{
    internal class ConfigReader
    {
        public static string GetTestDataValue(string key)
        {
            var data = JsonConvert.DeserializeObject(File.ReadAllText("../../../API/Resources/testdata.json")) as JObject;
            return data![key]!.Value<string>()!;
        }

        public static long GetNumericalTestDataValue(string key)
        {
            var data = JsonConvert.DeserializeObject(File.ReadAllText("../../../API/Resources/testdata.json")) as JObject;
            return Convert.ToInt64(data![key]!.Value<string>()!);
        }
        public static long GetConfigTestDataValue(string key)
        {
            var data = JsonConvert.DeserializeObject(File.ReadAllText("Resources/config.json")) as JObject;
            return Convert.ToInt64(data![key]!.Value<string>()!);
        }

        public static string GetConfigAppSettingValue(string key)
        {
            var json = File.ReadAllText("../../../Resources/Configuration/AppSettings.json");
            var data = JsonConvert.DeserializeObject<JObject>(json);

            // Convert colon-separated key to JSONPath format, e.g., "browser:Browser" -> "browser.Browser"
            var jsonPath = key.Replace(":", ".");

            var token = data?.SelectToken(jsonPath);
            return token?.ToString() ?? throw new Exception($"Key '{key}' not found in AppSettings.json");
        }

        public static string GetConfigUrls(string key)
        {
            var json = File.ReadAllText("../../../Resources/Configuration/Urls.json");
            var data = JsonConvert.DeserializeObject<JObject>(json);
            var token = data!.SelectToken(key.Replace(":", "."));
            return token?.ToString() ?? throw new Exception($"Key '{key}' not found in Urls.json");
        }
    }
}
