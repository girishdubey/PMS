using Newtonsoft.Json;
using PMS_Api.CryptoLibrary;
using PMS_Api.Filters;
using PMS_Entity.Model;
using PMS_Entity.Model.Master;
using PMS_Entity.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PMS_Entity;

namespace PMS_Api.Controllers
{
    [AuthoriseAPI]
    public class EmployeeController : ApiController
    {
        EmployeeRepository _EmployeeRepository;
        public EmployeeController()
        {
            _EmployeeRepository = new EmployeeRepository(new PMSDBContext());
        }
        // GET api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            //Getting All Employee Data from Database.
            return _EmployeeRepository.ListEmployeeDetail();
        }
        // GET api/employee/5
        [HttpGet]
        public HttpResponseMessage Get(string Id)
        {
            if (Id != null)
            {
                int _Id = Convert.ToInt32(Id);
                //Getting Employee Data from Database According to Id Passed.
                var Response = _EmployeeRepository.EmployeeDetailsByEmployeeNo(_Id);

                //Serializing Object which we have got from Database.
                string SerializeData = JsonConvert.SerializeObject(Response);

                //Encrypting Serialized Object.
                byte[] buffer = TripleDESAlgorithm.Encryption(SerializeData, ShareKeys.keyValue, ShareKeys.IVValue);

                //Sending Response.
                return Request.CreateResponse(HttpStatusCode.OK, Convert.ToBase64String(buffer));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee ID not found");
            }
        }
    }
}