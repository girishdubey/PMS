using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMSEntity.Interface;
using PMSEntity.Model.Master;

namespace PMSEntity.Repository
{
    public class HolidayRepository : IHoliday
    {
        PerformanceManagementDBContext _PMSDBEntities;
        public HolidayRepository(PerformanceManagementDBContext PMSDBEntities)
        {
            _PMSDBEntities = PMSDBEntities;
        }
        public Holiday HolidayDetailsByHolidayNo(int Holiday_Id)
        {
            var holidayDetail = from ad in _PMSDBEntities.Holidays
                                 where ad.Holiday_Id == Holiday_Id
                                 select ad;
            return holidayDetail.SingleOrDefault();
        }

        public List<Holiday> ListHolidayDetail()
        {
            return _PMSDBEntities.Holidays.ToList();
        }
    }
}
