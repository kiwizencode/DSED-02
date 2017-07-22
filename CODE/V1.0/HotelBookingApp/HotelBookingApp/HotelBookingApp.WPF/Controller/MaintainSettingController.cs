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
        SETTING_Model _selected;
        SETTING_ADO _data;

        public MaintainSettingController(IMaintainSettingView view)
        {
            _view = view;
            _data = new SETTING_ADO();
            _list = _data.Retreive();
        }

        #region Implementation of IController Interface
        public void AddNew()
        {
            _selected = new SETTING_Model(""/*Description*/);

            UpdateViewDetail(_selected);
            _view.SetViewButtonIsEnabled(true);
        }

        public void Edit()
        {
            _view.SetViewButtonIsEnabled(true);
        }

        public void LoadView()
        {
            _view.Clear_Grid();
            foreach (Abstract_Model obj in _list)
                _view.Add_To_Grid(obj);

            _view.ClearField();
            _view.SetViewButtonIsEnabled(false);
        }

        public void Remove()
        {
            Guid? id = this._view.GetSelectedID();
            Abstract_Model objToRemove = null;

            if (id != null)
            {
                foreach (Abstract_Model obj in this._list)
                {
                    if (obj.ID_PK == id)
                    {
                        objToRemove = obj;
                        break;
                    }
                }

                if (objToRemove != null)
                {
                    int newSelectedIndex = this._list.IndexOf(objToRemove);
                    _data.Delete(objToRemove);
                    _list.Remove(objToRemove);
                    _view.Remove_From_Grid(objToRemove);

                    if (newSelectedIndex > -1 && newSelectedIndex < _list.Count)
                    {
                        _view.SetSelectedInGrid((Abstract_Model)_list[newSelectedIndex]);
                    }
                }
            }
            _view.ClearField();
        }

        public void Revert()
        {
            _view.ClearField();
            _view.SetViewButtonIsEnabled(false);
        }

        public void Save()
        {
            UpdateModelDetail(_selected);
            if (!_list.Contains(_selected))
            {
                // Add new
                this._data.Create(_selected);
                _list = _data.Retreive();
                _selected = (SETTING_Model)_list[_list.Count - 1];
                _view.Add_To_Grid(_selected);
            }
            else
            {
                // Update 
                _data.Update(_selected);
                _view.Update_Grid(_selected);
            }
            _view.SetSelectedInGrid(_selected);
            _view.ClearField();
            _view.SetViewButtonIsEnabled(false);
        }

        public void SelectedModelChanged(Guid selected_ID)
        {
            foreach (Abstract_Model obj in this._list)
            {
                if (obj.ID_PK == selected_ID)
                {
                    _selected = obj as SETTING_Model;
                    UpdateViewDetail(obj);
                    _view.SetSelectedInGrid(obj);
                    break;
                }
            }
        }

        public void UpdateModelDetail(Abstract_Model obj)
        {
            SETTING_Model selectedUser = obj as SETTING_Model;
            selectedUser.ID_PK = _view.ID_PK;
            selectedUser.DESCRIPTION = _view.DESCRIPTION;
        }

        public void UpdateViewDetail(Abstract_Model obj)
        {
            SETTING_Model selectedUser = obj as SETTING_Model;
            _view.ID_PK = selectedUser.ID_PK;
            _view.DESCRIPTION = selectedUser.DESCRIPTION;
        }

        #endregion
    }

}
