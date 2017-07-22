using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Model;
using System.Collections;
using HotelBookingApp.ADO;

namespace HotelBookingApp.WPF.Controller
{
    public class MaintainBedSettingController : IController
    {
        IMaintainBedSettingView _view;
        IList _list;
        BED_SETTING_Model _selected;
        BED_SETTING_ADO _data;
        public MaintainBedSettingController(IMaintainBedSettingView view)
        {
            _view = view;
            _data = new BED_SETTING_ADO();
            _list = _data.Retreive(_view.SETTING_FK);
        }

        public void AddNew()
        {
            throw new NotImplementedException();
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void LoadView()
        {
            _view.Clear_Grid();
            foreach (Abstract_Model obj in _list)
                _view.Add_To_Grid(obj);
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Revert()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SelectedModelChanged(Guid selected_ID)
        {
            throw new NotImplementedException();
        }

        public void UpdateModelDetail(Abstract_Model obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateViewDetail(Abstract_Model obj)
        {
            throw new NotImplementedException();
        }
    }
}
