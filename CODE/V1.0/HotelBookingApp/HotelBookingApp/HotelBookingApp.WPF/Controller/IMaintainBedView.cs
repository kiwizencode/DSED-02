using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Model;

namespace HotelBookingApp.WPF.Controller
{
    public interface IMaintainBedView : IMaintainView
    {
        string DESCRIPTION { get; set; }
        int MAX_CAPACITY { get; set; }
    }
}
