using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMSEntity.Interface;
using PMSEntity.Model.Master;

namespace PMSEntity.Repository
{
    public class EmployeeRepository : IEmployee
    {
        PerformanceManagementDBContext _PMSDBEntities;
        public EmployeeRepository(PerformanceManagementDBContext PMSDBEntities)
        {
            _PMSDBEntities = PMSDBEntities;
        }
        public Employee EmployeeDetailsByEmployeeNo(int Id)
        {
            var employeeDetail = from ad in _PMSDBEntities.Employees
                                where ad.Id == Id
                                select ad;
            return employeeDetail.SingleOrDefault();
        }

        public List<Employee> ListEmployeeDetail()
        {
            return _PMSDBEntities.Employees.ToList();
        }
    }
}
