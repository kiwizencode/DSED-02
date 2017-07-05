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
        void UpdateViewDetail(ModelBaseClass obj);
        void UpdateModelDetail(ModelBaseClass obj);
        void SelectedModelChanged(Guid selectedBedId);
        void Remove();
        void Save();
    }
}
