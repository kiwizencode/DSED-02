using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.WPF.Controller
{
    public interface IMaintainBedSettingView : IMaintainView
    {
        Guid SETTING_FK { get; set; }
        Guid BED_FK { get; set; }
        int NUM { get; set; }
        string DESCRIPTION { get; set; }
    }
}
