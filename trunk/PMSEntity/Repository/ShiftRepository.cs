using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMSEntity.Interface;
using PMSEntity.Model.Master;

namespace PMSEntity.Repository
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
