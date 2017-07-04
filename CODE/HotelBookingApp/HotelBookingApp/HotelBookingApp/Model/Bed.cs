using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingApp.Model
{
    public partial class BED : ModelBaseClass
    {
        public Guid ID_PK { get; set; }
        public string DESCRIPTION { get; set; }
        public int MAX_CAPACITY { get; set; }

        public BED(string desc, int num)
        {
            DESCRIPTION = desc;
            MAX_CAPACITY = num;
        }
    }
}
