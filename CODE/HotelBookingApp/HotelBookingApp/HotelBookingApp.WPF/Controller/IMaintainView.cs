using System;
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
        void Add_To_Grid(Abstract_Model obj);
        void Update_Grid(Abstract_Model obj);
        void Remove_From_Grid(Abstract_Model obj);
        Guid? GetSelectedID();
        void SetSelectedInGrid(Abstract_Model obj);
        Guid ID_PK { get; set; }
        //bool CanModifyID { set; }
        void ClearField();

        void SetViewButtonIsEnabled();
    }
}
