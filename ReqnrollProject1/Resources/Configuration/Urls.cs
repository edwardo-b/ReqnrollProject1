using ReqnrollProject1.Utils;

namespace ReqnrollProject1.Resources.Configuration
{
    public static partial class Configuration
    {
   
    public static Uri ReporterFrontendUrl => new(ConfigReader.GetConfigUrls("Urls:WrsUrl"));
    
    }

   
}
