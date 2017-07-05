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

            UpdateViewDetail(_selected);
            _view.CanModifyID = true;
        }

        public void UpdateViewDetail(ModelBaseClass obj)
        {
            BED selectedUser = obj as BED;
            _view.ID_PK = selectedUser.ID_PK;
            _view.DESCRIPTION = selectedUser.DESCRIPTION;
            _view.MAX_CAPACITY = selectedUser.MAX_CAPACITY;
        }

        public void UpdateModelDetail(ModelBaseClass obj)
        {
            BED selectedUser = obj as BED;
            selectedUser.ID_PK = _view.ID_PK;
            selectedUser.DESCRIPTION = _view.DESCRIPTION;
            int i;
            if ( (  i = _view.MAX_CAPACITY ) !=-1)
                selectedUser.MAX_CAPACITY = i ;
        }

        public void SelectedModelChanged(Guid selectedBedId)
        {
            foreach (BED obj in this._list)
            {
                if (obj.ID_PK == selectedBedId)
                {
                    _selected = obj;
                    UpdateViewDetail(obj);
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

            //ClearViewDetail();
            _view.ClearField();
        }
        public void Save()
        {
            UpdateModelDetail(_selected);
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

            //ClearViewDetail();
            _view.ClearField();
        }

        /*

        public void ClearViewDetail()
        {
            _view.ID_PK = new Guid();
            _view.DESCRIPTION = string.Empty;
            _view.MAX_CAPACITY = 0;
        }         
         */
    }
}
