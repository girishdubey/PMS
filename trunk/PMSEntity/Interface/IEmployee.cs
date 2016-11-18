using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMSEntity.Model.Master;

namespace PMSEntity.Interface
{
    public interface IEmployee
    {
        List<Employee> ListEmployeeDetail();
        Employee EmployeeDetailsByEmployeeNo(int Id);
    }
}