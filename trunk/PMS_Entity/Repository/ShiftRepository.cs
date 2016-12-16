using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_Entity.Interface;
using PMS_Entity.Model.Master;

namespace PMS_Entity.Repository
{
    public class ShiftRepository : IShift
    {
        PerformanceManagementDBContext _PMSDBEntities;
        public ShiftRepository(PerformanceManagementDBContext PMSDBEntities)
        {
            _PMSDBEntities = PMSDBEntities;
        }
        public List<Shift> ListShiftDetail()
        {
            return _PMSDBEntities.Shifts.ToList();
        }

        public Shift ShiftDetailsByShiftNo(int Shift_Id)
        {
            var shiftDetail = from ad in _PMSDBEntities.Shifts
                              where ad.Shift_Id == Shift_Id
                              select ad;
            return shiftDetail.SingleOrDefault();
        }
    }
}
