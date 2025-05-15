using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ReqnrollProject1.Utils
{
    internal class ConfigReader
    {
        public static string GetTestDataValue(string key)
        {
            var data = JsonConvert.DeserializeObject(File.ReadAllText("C:Users/Edward.Osei-Bonsu/EdwardsALX/MyAutomation/ReqnrollProject1/Variable/AppSettings.json")) as JObject;
            return data![key]!.Value<string>()!;
        }

        public static long GetNumericalTestDataValue(string key)
        {
            var data = JsonConvert.DeserializeObject(File.ReadAllText("Resources/testdata.json")) as JObject;
            return Convert.ToInt64(data![key]!.Value<string>()!);
        }
        public static long GetConfigTestDataValue(string key)
        {
            var data = JsonConvert.DeserializeObject(File.ReadAllText("Resources/config.json")) as JObject;
            return Convert.ToInt64(data![key]!.Value<string>()!);
        }

        public static string GetConfigValue(string key)
        {
            var data = JsonConvert.DeserializeObject(File.ReadAllText("Resources/config.json")) as JObject;
            return data![key]!.Value<string>()!;
        }
    }
}
