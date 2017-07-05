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
        void LoadView();
        void AddNew();
        void UpdateViewDetail(Abstract_Model obj);
        void UpdateModelDetail(Abstract_Model obj);
        void SelectedModelChanged(Guid selectedBedId);
        void Remove();
        void Save();
        void Revert();
    }
}
