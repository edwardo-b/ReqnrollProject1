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
        private static readonly bool UseLocalFrontend = Convert.ToBoolean(ConfigReader.GetConfigAppSettingValue("useLocalServices:Frontend"));
        private static readonly bool UseLocalCMSApi = Convert.ToBoolean(ConfigReader.GetConfigAppSettingValue("useLocalServices:CMSApi"));
        private static readonly bool UseLocalCms = Convert.ToBoolean(ConfigReader.GetConfigAppSettingValue("useLocalServices:Cms"));
    }
}
