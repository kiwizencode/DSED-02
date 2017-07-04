using System;
using System.Collections.Generic;
using System.Text;
using HotelBookingApp.Model;
using System.Collections;

namespace HotelBookingApp.ADO
{
    public interface IDataADO
    {
        void Create(ModelBaseClass obj);
        IList Retreive();
        void Update(ModelBaseClass obj);
        void Delete(ModelBaseClass obj);
    }
}
