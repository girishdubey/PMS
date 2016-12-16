using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_Entity.Interface;
using PMS_Entity.Model.Master;

namespace PMS_Entity.Repository
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
