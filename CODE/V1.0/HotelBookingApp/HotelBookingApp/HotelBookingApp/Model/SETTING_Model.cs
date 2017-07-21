using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingApp.Model
{
    public class SETTING_Model : Abstract_Model
    {

        public string DESCRIPTION { get; set; }

        public SETTING_Model()
        {

        }
        public SETTING_Model(string desc)
        {
            DESCRIPTION = desc;
        }
    }
}
