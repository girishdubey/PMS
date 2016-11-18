using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMSEntity.Model.Master;

namespace PMSEntity.Interface
{
    public interface IHoliday
    {
        List<Holiday> ListHolidayDetail();
        Holiday HolidayDetailsByHolidayNo(int Holiday_Id);
    }
}