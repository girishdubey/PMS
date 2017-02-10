namespace PMS_Web_Token.Models
{
    using System;
    using System.Xml;
    using Configuration;

    public class APIKeyModel
    {
        private string _ServiceURI;
        private string _Token;
        private string _EncryKey;
        private string _IVKey;
        private string _UniqueID;
        private string _IPAddress;

        public APIKeyModel()
        {

            XmlDocument xDocConfig = new XmlDocument();
            string _strConfigPhysicalPath = string.Empty;
            string _strWebAppPath = AppDomain.CurrentDomain.BaseDirectory;
            _strConfigPhysicalPath = _strWebAppPath + ConfigurationHandler.ConfigFilePath;
            xDocConfig.Load(_strConfigPhysicalPath);

            _ServiceURI = ConfigurationHandler.GetAppSettingsFromDoc("ServiceURI", xDocConfig);
            _Token = ConfigurationHandler.GetAppSettingsFromDoc("Token", xDocConfig);
            _EncryKey = ConfigurationHandler.GetAppSettingsFromDoc("EncryKey", xDocConfig);
            _IVKey = ConfigurationHandler.GetAppSettingsFromDoc("IVKey", xDocConfig);
            _UniqueID = ConfigurationHandler.GetAppSettingsFromDoc("UniqueID", xDocConfig);
            _IPAddress = ConfigurationHandler.GetAppSettingsFromDoc("IPAddress", xDocConfig);
        }

        public string ServiceURI
        {
            get
            {
                return _ServiceURI;
            }
            set
            {
                _ServiceURI = value;
            }
        }
        public string Token
        {
            get
            {
                return _Token;
            }
            set
            {
                _Token = value;
            }
        }
        public string EncryKey
        {
            get
            {
                return _EncryKey;
            }
            set
            {
                _EncryKey = value;
            }
        }
        public string IVKey
        {
            get
            {
                return _IVKey;
            }
            set
            {
                _IVKey = value;
            }
        }
        public string UniqueID
        {
            get
            {
                return _UniqueID;
            }
            set
            {
                _UniqueID = value;
            }
        }
        public string IPAddress
        {
            get
            {
                return _IPAddress;
            }
            set
            {
                _IPAddress = value;
            }
        }
    }
}
