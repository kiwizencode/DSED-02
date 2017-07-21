using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingApp.Model
{
    public partial class BED_Model : Abstract_Model
    {
        public string DESCRIPTION { get; set; }
        public int MAX_CAPACITY { get; set; }

        public BED_Model()
        {

        }
        public BED_Model(string desc, int num)
        {
            DESCRIPTION = desc;
            MAX_CAPACITY = num;
        }
    }
}
