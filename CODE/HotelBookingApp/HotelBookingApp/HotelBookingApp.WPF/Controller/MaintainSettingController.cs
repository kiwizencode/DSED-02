using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Model;
using HotelBookingApp.ADO;
using System.Collections;

namespace HotelBookingApp.WPF.Controller
{
    public class MaintainSettingController : IController
    {
        IMaintainSettingView _view;
        IList _list;
        BED_Model _selected;
        BED_ADO _data;

        public MaintainSettingController(IMaintainSettingView view)
        {
            _view = view;
            _data = new BED_ADO();
            _list = _data.Retreive();
        }

        public void AddNew()
        {
            throw new NotImplementedException();
        }

        public void LoadView()
        {
            _view.Clear_Grid();
            foreach (Abstract_Model obj in _list)
                _view.Add_To_Grid(obj);

            //_view.SetSelectedInGrid((Abstract_Model)_list[0]);
            _view.ClearField();
            _view.SetViewButtonIsEnabled();
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

        public void SelectedModelChanged(Guid selectedBedId)
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
