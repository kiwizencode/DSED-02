using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Model;
using HotelBookingApp.ADO;

namespace HotelBookingApp.WPF.Controller
{
    public class MaintainBedController : IController
    {
        IMaintainBedView _view;
        IList _list;
        BED_Model _selected;
        BED_ADO _data;

        public MaintainBedController(IMaintainBedView view)
        {
            _view = view;
            _data = new BED_ADO();
            _list = _data.Retreive();
        }

        #region Implementation of IController Interface

        public void AddNew()
        {
            _selected = new BED_Model(""/*Description*/, 0 /*Max Capacity*/);

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

            //_view.SetSelectedInGrid((Abstract_Model)_list[0]);
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

                // remove bed object
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

            //ClearViewDetail();
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
                // Add new bed
                this._data.Create(_selected);
                _list = _data.Retreive();
                _selected = (BED_Model)_list[_list.Count - 1];
                _view.Add_To_Grid(_selected);
            }
            else
            {
                // Update 
                _data.Update(_selected);
                _view.Update_Grid(_selected);
                _view.SetSelectedInGrid(_selected);
            }

            _view.ClearField();
            _view.SetViewButtonIsEnabled(false);
        }

        public void SelectedModelChanged(Guid selected_ID)
        {
            foreach (BED_Model obj in this._list)
            {
                if (obj.ID_PK == selected_ID)
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
            BED_Model selectedUser = obj as BED_Model;
            selectedUser.ID_PK = _view.ID_PK;
            selectedUser.DESCRIPTION = _view.DESCRIPTION;
            int i;
            if ((i = _view.MAX_CAPACITY) != -1)
                selectedUser.MAX_CAPACITY = i;
        }

        public void UpdateViewDetail(Abstract_Model obj)
        {
            BED_Model selectedUser = obj as BED_Model;
            _view.ID_PK = selectedUser.ID_PK;
            _view.DESCRIPTION = selectedUser.DESCRIPTION;
            _view.MAX_CAPACITY = selectedUser.MAX_CAPACITY;
        }

        #endregion

    }
}
