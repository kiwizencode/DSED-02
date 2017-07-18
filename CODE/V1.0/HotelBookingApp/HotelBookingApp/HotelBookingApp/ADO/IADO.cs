using System;
using System.Collections.Generic;
using System.Text;
using HotelBookingApp.Model;
using System.Collections;

namespace HotelBookingApp.ADO
{
    public interface IADO
    {
        void Create(Abstract_Model obj);
        IList Retreive();
        void Update(Abstract_Model obj);
        void Delete(Abstract_Model obj);
    }
}
