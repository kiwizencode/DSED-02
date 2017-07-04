﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Model;

namespace HotelBookingApp.WPF.Controller
{
    public interface IMaintainView
    {
        void Clear_Grid();
        void Add_To_Grid(ModelBaseClass obj);
        void Update_Grid(ModelBaseClass obj);
        void Remove_From_Grid(ModelBaseClass obj);
        Guid? GetSelectedID();
        void SetSelectedInGrid(ModelBaseClass obj);

        Guid ID_PK { get; set; }

        bool CanModifyID { set; }
    }
}
