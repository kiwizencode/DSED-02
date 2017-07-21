using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingApp.Model
{
    public abstract class Abstract_Model
    {
        public Guid ID_PK;
        public string GUID { get => ID_PK.ToString(); }
    }
}
