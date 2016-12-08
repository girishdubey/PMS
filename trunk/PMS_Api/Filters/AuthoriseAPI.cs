using PMS_Api.CryptoLibrary;
using PMSEntity.Model;
using PMSEntity.Model.Master;
using PMSEntity.Interface;
using PMSEntity.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.IO;

namespace PMS_Api.Filters
{
    public class AuthoriseAPI : AuthorizeAttribute
    {
        IRegistration _IRegistration;

        public AuthoriseAPI()
        {
            StringBuilder sb = new StringBuilder(1024);
            DebugLog("AuthoriseAPI 1:", sb);
            WriteLog("IsAuthorized", sb);
            _IRegistration = new RegistrationRepository(new PMSEntity.PerformanceManagementDBContext());
            DebugLog("AuthoriseAPI 2:", sb);
            WriteLog("IsAuthorized", sb);
        }


        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            StringBuilder sb = new StringBuilder(1024);
            try
            {
                IEnumerable<string> tokenHeaders;
                if (actionContext.Request.Headers.TryGetValues("APIKEY", out tokenHeaders))
                {
                    string tokens = tokenHeaders.First();
                    DebugLog("tokens:"+ tokens, sb);
                    string key1 = Encoding.UTF8.GetString(Convert.FromBase64String(tokens));
                    DebugLog("key1:" + key1, sb);
                    string[] Data = key1.Split(new char[] { ':' });

                    if (tokens != null && Data != null)
                    {
                        string encry1 = Data[0]; //UniqueID
                        string encry2 = Data[1]; //DateTime with Ticks
                        string encry3 = Data[2]; //ClientToken + IPAddress +Ticks

                        if (_IRegistration.GetEncryptionDecryptionKeys(encry1) == null)
                        {
                            DebugLog("GetEncryptionDecryptionKeys: is null", sb);
                            WriteLog("IsAuthorized", sb);
                            return false;
                        }
                        else
                        {
                            var KeysValues = _IRegistration.GetEncryptionDecryptionKeys(encry1);
                            //Hash Decryption
                            string DecryHash2 = TripleDESAlgorithm.Decryption(encry3, KeysValues.EncryKey, KeysValues.IVKey);
                            string[] Key2 = DecryHash2.Split(new char[] { ':' });

                            // 1)ClientToken
                            string ClientToken = Key2[0];

                            // 2)IPAddress
                            string IPAddress = Key2[1];

                            // 3)Ticks
                            long ticks = long.Parse(Key2[2]);

                            //ReValidating token Exists in Database or not
                            if (_IRegistration.ValidateToken(ClientToken.ToLower()) == null)
                            {
                                DebugLog("ValidateToken: is null", sb);
                                WriteLog("IsAuthorized", sb);
                                return false;
                            }
                            else
                            {
                                var Returndata = _IRegistration.ValidateToken(ClientToken.ToLower());

                                ShareKeys.IVValue = Returndata.IVKey;
                                ShareKeys.keyValue = Returndata.EncryKey;
                                DateTime currentdate = new DateTime(ticks);

                                //Comparing Current Date with date sent
                                bool timeExpired = Math.Abs((DateTime.UtcNow - currentdate).TotalMinutes) > 10;

                                if (!timeExpired)
                                {
                                    if (string.Equals(ClientToken.ToLower(), Returndata.Token.ToLower(), comparisonType: StringComparison.InvariantCulture) == true)
                                    {
                                        DebugLog("token valid", sb);
                                        WriteLog("IsAuthorized", sb);
                                        return true;
                                    }
                                    else
                                    {
                                        DebugLog("taken not valid", sb);
                                        WriteLog("IsAuthorized", sb);
                                        return false;
                                    }
                                }
                                else
                                {
                                    DebugLog("time expired", sb);
                                    WriteLog("IsAuthorized", sb);
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        DebugLog("tokens is null or Data is null ", sb);
                        WriteLog("IsAuthorized", sb);
                        return false;
                    }
                }
                else
                {
                    DebugLog("APIKEY is null ", sb);
                    WriteLog("IsAuthorized", sb);
                    return false;
                }
            }
            catch (Exception ex)
            {
                DebugLog(ex.Message, sb);
                WriteLog("IsAuthorized", sb);
                throw;
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new System.Net.Http.HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Content = new StringContent("Not Valid Client!")
            };
        }

        private void DebugLog(string Content, StringBuilder sb)
        {
            sb.AppendLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt ") + Content);
        }
        private void WriteLog(string LogKey, StringBuilder sb)
        {
            try
            {
                string LOGPath = System.Configuration.ConfigurationManager.AppSettings["LogPath"];
                string timestamp = DateTime.Now.ToString("dd-MMM-yyyy");
                string path = LOGPath +"/"+ LogKey + "/" + timestamp + ".txt";
                if (!Directory.Exists(LOGPath + "/" + LogKey))
                    Directory.CreateDirectory(LOGPath + "/" + LogKey);
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    StringBuilder Content = new StringBuilder(1024);
                    Content.AppendLine("=====================Start LogKey=====================");
                    Content.AppendLine("=====================" + DateTime.Now.ToString("dd-MMM-yyyy  HH:mm:ss") + "=====================");
                    Content.AppendLine(sb.ToString());
                    Content.AppendLine("=====================End LogKey=====================");
                    writer.WriteLine(Content);
                    writer.Close();
                    sb.Length = 0;
                    Content.Length = 0;
                }
                //System.IO.File.WriteAllText(path, sb.ToString());
            }
            catch
            {

            }
        }
    }
}