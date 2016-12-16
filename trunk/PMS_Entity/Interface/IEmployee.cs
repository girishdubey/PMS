using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMS_Entity.Model.Master;

namespace PMS_Entity.Interface
{
    public interface IEmployee
    {
        List<Employee> ListEmployeeDetail();
        Employee EmployeeDetailsByEmployeeNo(int Id);
    }
}