using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingApp.Model
{
    public class RoomSetting
    {
        public int Room_FK { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }
        public float Max { get; set; }
        public int Count { get; set; }
    }
}
