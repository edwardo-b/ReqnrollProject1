using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ReqnrollProject1.Utils
{
    internal static class ExtensionUtilities
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                var attribute = (DescriptionAttribute)field
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault();

                return attribute?.Description ?? value.ToString();
            }

            return value.ToString();
        }

        public static Uri AddRelativePath(this Uri baseUrl, string partToAdd)
        {
            if (baseUrl == null) throw new ArgumentNullException(nameof(baseUrl));
            if (string.IsNullOrEmpty(partToAdd)) return baseUrl;

            string basePath = baseUrl.AbsoluteUri.EndsWith("/") ? baseUrl.AbsoluteUri : baseUrl.AbsoluteUri + "/";
            string relativePath = partToAdd.TrimStart('/');

            return new Uri(new Uri(basePath), relativePath);
        }
    }
}
