using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.WPF.Controller
{
    public interface IMaintainSettingView : IMaintainView
    {
        string DESCRIPTION { get; set; }
    }
}
