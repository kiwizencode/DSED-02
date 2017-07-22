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
        Guid ID_PK { get; set; }

        void Add_To_Grid(Abstract_Model obj);
        void Clear_Grid();
        Guid? GetSelectedID();
        void Remove_From_Grid(Abstract_Model obj);
        void SetSelectedInGrid(Abstract_Model obj);
        void Update_Grid(Abstract_Model obj);
        void ClearField();
        void SetViewButtonIsEnabled(Boolean flag);
    }
}
