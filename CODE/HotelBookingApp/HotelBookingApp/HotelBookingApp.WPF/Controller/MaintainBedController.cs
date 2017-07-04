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
            foreach (User usr in _users)
                _view.AddUserToGrid(usr);

            _view.SetSelectedUserInGrid((User)_users[0]);

        }

        public void AddNew()
        {
            _selected = new BED( ""/*Description*/, 0 /*Max Capacity*/);

            this.updateView(_selected);
            this._view.CanModifyID = true;
        }

        private void updateView(BED selectedUser)
        {
            _view.ID_PK = selectedUser.ID_PK;
            _view.DESCRIPTION = selectedUser.DESCRIPTION;
            _view.MAX_CAPACITY = selectedUser.MAX_CAPACITY;
        }

        public void SelectedUserChanged(Guid selectedBedId)
        {
            foreach (BED obj in this._list)
            {
                if (obj.ID_PK == selectedBedId)
                {
                    _selected = obj;
                    updateView(obj);
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
            updateView(_selected);
            if (!this._list.Contains(_selected))
            {
                // Add new bed
                this._list.Add(_selected);
                this._view.Add_To_Grid(_selected);
            }
            else
            {
                // Update existing bed
                this._view.Update_Grid(_selected);
            }
            _view.SetSelectedInGrid(_selected);
            this._view.CanModifyID = false;

        }
    }
}
