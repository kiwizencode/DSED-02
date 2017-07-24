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
            
            //_view.Refresh_Grid(_list);
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Revert()
        {
            _view.ClearField();
            _view.SetViewButtonIsEnabled(false);
        }

        public void Save()
        {
            UpdateModelDetail(_selected);
            if (_selected.ID_PK.ToString() == (new Guid()).ToString())
            {
                // Add New Record
            }
            else
            {
                // Update Record
            }
            _view.Update_Grid(_selected);
            _view.SetSelectedInGrid(_selected);
            _view.ClearField();
            _view.SetViewButtonIsEnabled(false);
        }

        public void SelectedModelChanged(Guid selected_ID)
        {
            throw new NotImplementedException();
        }

        public void SelectedModelChanged(string des)
        {
            foreach (BED_SETTING_Model obj in this._list)
            {
                if (obj.DESCRIPTION == des)
                {
                    _selected = obj;
                    UpdateViewDetail(obj);
                    _view.SetSelectedInGrid(obj);
                    break;
                }
            }
        }

        public void UpdateModelDetail(Abstract_Model obj)
        {
            BED_SETTING_Model selectedUser = obj as BED_SETTING_Model;
            selectedUser.ID_PK = _view.ID_PK;
            selectedUser.SETTING_FK = _view.SETTING_FK;
            selectedUser.BED_FK = _view.BED_FK;
            selectedUser.DESCRIPTION = _view.DESCRIPTION;
            selectedUser.NUM = _view.NUM;
        }

        public void UpdateViewDetail(Abstract_Model obj)
        {
            BED_SETTING_Model selectedUser = obj as BED_SETTING_Model;
            _view.ID_PK = selectedUser.ID_PK;
            //_view.SETTING_FK = selectedUser.SETTING_FK;
            _view.BED_FK = selectedUser.BED_FK;
            _view.DESCRIPTION = selectedUser.DESCRIPTION;
            _view.NUM = selectedUser.NUM;
        }
    }
}
