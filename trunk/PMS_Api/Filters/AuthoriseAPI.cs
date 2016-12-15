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
            _IRegistration = new RegistrationRepository(new PMSEntity.PerformanceManagementDBContext());
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
                    string key1 = Encoding.UTF8.GetString(Convert.FromBase64String(tokens));
                    string[] Data = key1.Split(new char[] { ':' });

                    if (tokens != null && Data != null)
                    {
                        string encry1 = Data[0]; //UniqueID
                        string encry2 = Data[1]; //DateTime with Ticks
                        string encry3 = Data[2]; //ClientToken + IPAddress +Ticks

                        if (_IRegistration.GetEncryptionDecryptionKeys(encry1) == null)
                        {
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
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
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
    }
}