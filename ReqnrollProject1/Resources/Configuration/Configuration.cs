using ReqnrollProject1.Resources.Models;
using ReqnrollProject1.Utils;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Resources.Configuration
{
    public static partial class Configuration
    {
        public static string GetBrowser => ConfigReader.GetConfigAppSettingValue("browser:Browser") ?? "chrome";

    }
}
