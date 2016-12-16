using PMS_Web.CryptoLibrary;
using System;
using System.Configuration;
using System.Text;

namespace PMS_Web.APIToken
{
    public class GenerateToken
    {
        public static string CreateToken(string IPAddress, string Token, long ticks)
        {
            string hashLeft = string.Empty;
            string hashRight = string.Empty;
            string encry1 = string.Empty;
            string encry2 = string.Empty;

            try
            {
                string key = Convert.ToString(ConfigurationManager.AppSettings["keyValue"]);
                string IV = Convert.ToString(ConfigurationManager.AppSettings["IVValue"]);
                string UniqueID = Convert.ToString(ConfigurationManager.AppSettings["UniqueID"]);

                // [encry1] CLientIDToken : IPAddress : ticks 
                encry1 = string.Join(":", new string[] { Token, IPAddress, ticks.ToString() });

                // [encry2] UniqueID + ticks 
                hashLeft = Convert.ToBase64String(TripleDESAlgorithm.Encryption(encry1, key, IV));
                hashRight = string.Join(":", new string[] { UniqueID, ticks.ToString() });

                // [CLientIDToken : IPAddress : ticks + UniqueID + ticks]

                var basestring = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hashRight, hashLeft)));

                return basestring;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}