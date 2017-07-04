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
    public class MaintainBedController
    {
        IMaintainBedView _view;
        IList _list;
        BED _selected;
        BED_ADO _data;

        public MaintainBedController(IMaintainBedView view)
        {
            _view = view;
            _data = new BED_ADO();
            _list = _data.Retreive();
            //view.Set_Controller(this);
        }

        public void LoadView()
        {
            _view.Clear_Grid();
            foreach (ModelBaseClass obj in _list)
                _view.Add_To_Grid(obj);

            _view.SetSelectedInGrid((ModelBaseClass)_list[0]);

        }

        public void AddNew()
        {
            _selected = new BED( ""/*Description*/, 0 /*Max Capacity*/);

            this.updateViewDetail(_selected);
            this._view.CanModifyID = true;
        }

        private void updateViewDetail(ModelBaseClass obj)
        {
            BED selectedUser = obj as BED;
            _view.ID_PK = selectedUser.ID_PK;
            _view.DESCRIPTION = selectedUser.DESCRIPTION;
            _view.MAX_CAPACITY = selectedUser.MAX_CAPACITY;
        }

        private void updateBedDetail(ModelBaseClass obj)
        {
            BED selectedUser = obj as BED;
            selectedUser.ID_PK = _view.ID_PK;
            selectedUser.DESCRIPTION = _view.DESCRIPTION.TrimEnd();
            selectedUser.MAX_CAPACITY = _view.MAX_CAPACITY;
        }

        public void SelectedUserChanged(Guid selectedBedId)
        {
            foreach (BED obj in this._list)
            {
                if (obj.ID_PK == selectedBedId)
                {
                    _selected = obj;
                    updateViewDetail(obj);
                    _view.SetSelectedInGrid(obj);
                    this._view.CanModifyID = false;
                    break;
                }
            }
        }

        public void Remove()
        {
            Guid? id = this._view.GetSelectedID();
                
            BED objToRemove = null;

            if (id != null)
            {
                foreach (BED obj in this._list)
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
                    this._list.Remove(objToRemove);
                    this._view.Remove_From_Grid(objToRemove);

                    if (newSelectedIndex > -1 && newSelectedIndex < _list.Count)
                    {
                        this._view.SetSelectedInGrid((BED)_list[newSelectedIndex]);
                    }
                }
            }
        }
        public void Save()
        {
            updateBedDetail(_selected);
            if (!this._list.Contains(_selected))
            {
                // Add new bed
                this._data.Create(_selected);
                _list = _data.Retreive();
                _selected = (BED)_list[_list.Count-1];
                //this._list.Add(_selected);
                this._view.Add_To_Grid(_selected);
            }
            else
            {
                // Update existing bed
                _data.Update(_selected);
                this._view.Update_Grid(_selected);
            }
            _view.SetSelectedInGrid(_selected);
            this._view.CanModifyID = false;

        }
    }
}
