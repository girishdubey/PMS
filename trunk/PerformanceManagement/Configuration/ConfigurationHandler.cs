using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace PerformanceManagement.Configuration
{
    public static class ConfigurationHandler
    {
        public static string GetAppSettings(string key)
        {
            string Value = "";
            try
            {
                Value = ConfigurationManager.AppSettings[key].ToString();
            }
            catch (Exception)
            {
                Value = "";
            }
            return Value;
        }
        
    }
}