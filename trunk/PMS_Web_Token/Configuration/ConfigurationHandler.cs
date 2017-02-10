namespace PMS_Web_Token.Configuration
{
    using System;
    using System.Xml;

    public static class ConfigurationHandler
    {
        private static string _ConfigFilePath = @"\App_Data\Configuration\PMS_API_Configuration.xml";

        public static string ConfigFilePath
        {
            get
            {
                return _ConfigFilePath;
            }
        }

        public static string GetAppSettings(string key)
        {
            string Value = "";
            try
            {
                Value = GetValue(key);
            }
            catch (Exception)
            {
                Value = "";
            }
            return Value;
        }

        internal static string GetAppSettingsFromDoc(string key, XmlDocument xDocConfig)
        {
            string Value = "";
            try
            {
                Value = GetValueFromDoc(key, xDocConfig);
            }
            catch (Exception)
            {
                Value = "";
            }
            return Value;
        }

        private static string GetValue(string strXPath)
        {
            XmlDocument xDocConfig = new XmlDocument();
            string _strConfigPhysicalPath = string.Empty;

            string _strWebAppPath = AppDomain.CurrentDomain.BaseDirectory;
            _strConfigPhysicalPath = _strWebAppPath + ConfigFilePath;
            xDocConfig.Load(_strConfigPhysicalPath);
            string _strValue = string.Empty;
            if (xDocConfig.DocumentElement != null)
            {
                if (xDocConfig.DocumentElement.Name.ToUpper().Equals("CONFIGURATION"))
                {
                    if (xDocConfig.DocumentElement.SelectSingleNode(strXPath) != null)
                    {
                        _strValue = xDocConfig.DocumentElement.SelectSingleNode(strXPath).InnerText;
                    }
                }
            }
            return _strValue;
        }

        private static string GetValueFromDoc(string strXPath, XmlDocument xDocConfig)
        {
            string _strValue = string.Empty;
            if (xDocConfig.DocumentElement != null)
            {
                if (xDocConfig.DocumentElement.Name.ToUpper().Equals("CONFIGURATION"))
                {
                    if (xDocConfig.DocumentElement.SelectSingleNode(strXPath) != null)
                    {
                        _strValue = xDocConfig.DocumentElement.SelectSingleNode(strXPath).InnerText;
                    }
                }
            }
            return _strValue;
        }
    }
}
