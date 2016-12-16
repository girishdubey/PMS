using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMS_Entity.Model.Master;

namespace PMS_Entity.Interface
{
    public interface IHoliday
    {
        List<Holiday> ListHolidayDetail();
        Holiday HolidayDetailsByHolidayNo(int Holiday_Id);
    }
}