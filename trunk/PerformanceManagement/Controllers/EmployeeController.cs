using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PerformanceManagement.APIToken;
using PerformanceManagement.Configuration;
using PerformanceManagement.CryptoLibrary;
using PMSEntity.Model;
using PMSEntity.Model.Master;

namespace PerformanceManagement.Controllers
{
    public class EmployeeController : Controller
    {
        string Token = ConfigurationHandler.GetAppSettings("Token");
        string keyValue = ConfigurationHandler.GetAppSettings("keyValue");
        string IVValue = ConfigurationHandler.GetAppSettings("IVValue");
        string IPAddress = ConfigurationHandler.GetAppSettings("IPAddress");
        string ServiceURI = ConfigurationHandler.GetAppSettings("ServiceURI");
        [HttpGet]
        public async Task<ActionResult> IndexAsync()
        {
            // We are using async task
            await Task.Run(() => GetAllAccountDetails());
            return View();
        }

        // Getting Data
        [NonAction]
        public void GetAllAccountDetails()
        {
            using (var client = new WebClient()) //WebClient  
            {
                // URI 
                Uri URI = new Uri(ServiceURI + "api/employee/1");
                client.Headers.Add("Content-Type:application/json");
                // Generating token
                client.Headers.Add("APIKEY", GenerateToken.CreateToken(IPAddress, Token, DateTime.UtcNow.Ticks));
                client.Headers.Add("Accept:application/json");
                //Setting Callback
                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadString_Callback);
                client.DownloadStringAsync(URI);
            }
        }

        [NonAction]
        void DownloadString_Callback(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                #region ErrorCode
                object objException = e.Error.GetBaseException();

                Type _type = typeof(WebException);
                if (_type != null)
                {
                    WebException objErr = (WebException)e.Error.GetBaseException();
                    WebResponse rsp = objErr.Response;
                    using (Stream respStream = rsp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respStream);
                        string text = reader.ReadToEnd();
                    }
                }
                else
                {
                    Exception objErr = (Exception)e.Error.GetBaseException();
                }
                #endregion
            }
            else if (e.Result != null || !string.IsNullOrEmpty(e.Result))
            {

                string finalData = JToken.Parse(e.Result).ToString();


                string data = TripleDESAlgorithm.Decryption(finalData, keyValue, IVValue);


                Employee AccountDetail = JsonConvert.DeserializeObject<Employee>(data);


            }
        }

    }
}