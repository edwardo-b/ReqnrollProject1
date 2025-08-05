using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ReqnrollProject1.Utils
{
    internal class ConfigReader
    {
        public static string GetTestDataValue(string key)
        {
            var data = JsonConvert.DeserializeObject(File.ReadAllText("../Resources/testdata.json")) as JObject;
            return data![key]!.Value<string>()!;
        }

        public static long GetNumericalTestDataValue(string key)
        {
            var data = JsonConvert.DeserializeObject(File.ReadAllText("../Resources/testdata.json")) as JObject;
            return Convert.ToInt64(data![key]!.Value<string>()!);
        }

        public static string GetConfigAppSettingValue(string key)
        {
            var json = File.ReadAllText("../../../Resources/AppSettings.json");
            var data = JsonConvert.DeserializeObject<JObject>(json);

            // Convert colon-separated key to JSONPath format, e.g., "browser:Browser" -> "browser.Browser"
            var jsonPath = key.Replace(":", ".");

            var token = data?.SelectToken(jsonPath);
            return token?.ToString() ?? throw new Exception($"Key '{key}' not found in AppSettings.json");
        }
        //public static string GetConfigAppSettingValue(string key)
        //{
        //    var basePath = AppContext.BaseDirectory;
        //    var fullPath = Path.Combine(basePath, "Resources", "", "AppSettings.json");

        //    if (!File.Exists(fullPath))
        //        throw new FileNotFoundException($"AppSettings.json not found at {fullPath}");

        //    var json = File.ReadAllText(fullPath);
        //    var data = JsonConvert.DeserializeObject<JObject>(json);

        //    var jsonPath = key.Replace(":", ".");
        //    var token = data?.SelectToken(jsonPath);

        //    return token?.ToString() ?? throw new Exception($"Key '{key}' not found in AppSettings.json");
        //}

    }
}
