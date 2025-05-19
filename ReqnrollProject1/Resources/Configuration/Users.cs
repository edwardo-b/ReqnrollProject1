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

        private static string? managerUserName;
        private static string? managerUserPassword;

        public static string ManagerUsername
        {
            get => string.IsNullOrEmpty(managerUserName)
                ? ConfigReader.GetConfigAppSettingValue("users:ManagerUsername")
                : managerUserName;
            set => managerUserName = value;
        }

        public static string ManagerPassword
        {
            get => string.IsNullOrEmpty(managerUserPassword)
                ? ConfigReader.GetConfigAppSettingValue("users:ManagerPassword")
                : managerUserPassword;
            set => managerUserPassword = value;
        }
    }
}
