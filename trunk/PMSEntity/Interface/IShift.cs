using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMSEntity.Model.Master;

namespace PMSEntity.Interface
{
    public interface IShift
    {
        List<Shift> ListShiftDetail();
        Shift ShiftDetailsByShiftNo(int Shift_Id);
    }
}