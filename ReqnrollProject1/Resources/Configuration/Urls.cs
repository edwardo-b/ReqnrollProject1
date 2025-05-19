using ReqnrollProject1.Resources.Models;
using ReqnrollProject1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Resources.Configuration
{
    public static partial class Configuration
    {
   
    public static Uri FrontendUrl => UseLocalFrontend
    ? new Uri(ConfigReader.GetConfigAppSettingValue("localServiceUrls:FrontendUrl"))
    : new Uri(ConfigReader.GetConfigAppSettingValue("Urls:FrontendUrl"));

    public static Uri SpecificFrontendUrl(Franchise franchise) => UseLocalFrontend
    ? new(ConfigReader.GetConfigAppSettingValue("localServiceUrls:FrontendUrl"))
    : new Uri(new Uri(ConfigReader.GetConfigAppSettingValue("Urls:FrontendUrl")), franchise.GetDescription());


        public static Uri CmsUrl => UseLocalCms
     ? new(ConfigReader.GetConfigAppSettingValue("localServiceUrls:CmsUrl"))
     : new Uri(ConfigReader.GetConfigAppSettingValue("Urls:CmsUrl")).AddRelativePath("manager");


    public static Uri CmsApiUrl => UseLocalCMSApi
    ? new(ConfigReader.GetConfigAppSettingValue("localServiceUrls:CMSApiUrl"))
    : new Uri(ConfigReader.GetConfigAppSettingValue("Urls:CMSApiUrl"));



    }

   
}
