using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Model;
using System.Collections;

namespace HotelBookingApp.WPF.Controller
{
    public interface IController
    {
        void AddNew();
        void Edit();
        void LoadView();
        void Remove();
        void Revert();
        void Save();
        void SelectedModelChanged(Guid selected_ID);
        void UpdateModelDetail(Abstract_Model obj);
        void UpdateViewDetail(Abstract_Model obj);
    }
}
