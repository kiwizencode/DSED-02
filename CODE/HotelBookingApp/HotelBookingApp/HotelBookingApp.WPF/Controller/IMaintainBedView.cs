using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Model;

namespace HotelBookingApp.WPF.Controller
{
    public interface IMaintainBedView 
    {
        //void Set_Controller(MaintainBedController controller);
        void Clear_Grid();
        void Add_To_Grid(BED bed);
        void Update_Grid(BED bed);
        void Remove_From_Grid(BED bed);
        Guid? GetSelectedID();
        void SetSelectedInGrid(BED bed);

        Guid ID_PK { get; set; }
        string DESCRIPTION { get; set; }
        int MAX_CAPACITY { get; set; }
        bool CanModifyID { set; }
    }
}
