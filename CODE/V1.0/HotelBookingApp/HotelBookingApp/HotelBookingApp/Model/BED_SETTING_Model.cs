using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingApp.Model
{
    public class BED_SETTING_Model : Abstract_Model
    {
        public Guid SETTING_FK;
        public Guid BED_FK;
        public int NUM;
        public string DESCRIPTION;

        public string SETTING_GUID { get => SETTING_FK.ToString(); }
        public string BED_GUID { get => BED_FK.ToString(); }
    }
}
