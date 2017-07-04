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
        public int Max { get; set; }
        public int Count { get; set; }

        public RoomSetting( int data_id, string data_description, 
                            float data_cost, int data_max, int data_count)
        {
            Room_FK = data_id;
            Description = data_description;
            Cost = data_cost;
            Max = data_max;
            Count = data_count;
        }

        public override string ToString()
        {
            return "room " + Room_FK + " " + Description + " " + Count;
        }
    }
}
