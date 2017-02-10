namespace PMS_Web_Token
{
    using System;
    using System.Text;
    using Models;
    using CryptoLibrary;

    public class APIToken
    {
        public static string GetAPIKey()
        {
            string hashLeft = string.Empty;
            string hashRight = string.Empty;
            string encry1 = string.Empty;
            string ticks;
            try
            {
                APIKeyModel _Model = new APIKeyModel();
                ticks = DateTime.UtcNow.Ticks.ToString();
                // [encry1] CLientIDToken : IPAddress : ticks 
                encry1 = string.Join(":", new string[] { _Model.Token, _Model.IPAddress, ticks });

                // [encry2] UniqueID + ticks 
                hashLeft = Convert.ToBase64String(TripleDESAlgorithm.Encryption(encry1, _Model.EncryKey, _Model.IVKey));
                hashRight = string.Join(":", new string[] { _Model.UniqueID, ticks.ToString() });

                // [CLientIDToken : IPAddress : ticks + UniqueID + ticks]

                var basestring = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hashRight, hashLeft)));

                return basestring;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetAPIKey(APIKeyModel Model)
        {
            string hashLeft = string.Empty;
            string hashRight = string.Empty;
            string encry1 = string.Empty;
            string ticks;
            try
            {
                ticks = DateTime.UtcNow.Ticks.ToString();
                // [encry1] CLientIDToken : IPAddress : ticks 
                encry1 = string.Join(":", new string[] { Model.Token, Model.IPAddress, ticks });

                // [encry2] UniqueID + ticks 
                hashLeft = Convert.ToBase64String(TripleDESAlgorithm.Encryption(encry1, Model.EncryKey, Model.IVKey));
                hashRight = string.Join(":", new string[] { Model.UniqueID, ticks.ToString() });

                // [CLientIDToken : IPAddress : ticks + UniqueID + ticks]

                var basestring = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hashRight, hashLeft)));

                return basestring;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static byte[] Encryption(string PlainText)
        {
            APIKeyModel _Model = new APIKeyModel();
            return TripleDESAlgorithm.Encryption(PlainText, _Model.EncryKey, _Model.IVKey);
        }

        public static byte[] Encryption(string PlainText, APIKeyModel Model)
        {
            return TripleDESAlgorithm.Encryption(PlainText, Model.EncryKey, Model.IVKey);
        }

        public static string Decryption(string CypherText)
        {
            APIKeyModel _Model = new APIKeyModel();
            return TripleDESAlgorithm.Decryption(CypherText, _Model.EncryKey, _Model.IVKey);
        }

        public static string Decryption(string CypherText, APIKeyModel Model)
        {
            return TripleDESAlgorithm.Decryption(CypherText, Model.EncryKey, Model.IVKey);
        }
    }
}
