using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HotelBookingApp.Model;
using HotelBookingApp.WPF.Controller;

namespace HotelBookingApp.WPF.View
{
    /// <summary>
    /// Interaction logic for MaintainBedPage.xaml
    /// </summary>
    public partial class MaintainBedPage : Page, IMaintainBedView
    {
        private MaintainBedController _controller;

        #region Implement IMaintainBedView Interface code
        public string DESCRIPTION {
            get => txtDescription.Text ;
            set => txtDescription.Text=value.TrimEnd();
        }
        private Guid _ID;
        public Guid ID_PK
        {
            get => _ID;
            set { _ID = value; txtGUID.Text = _ID.ToString(); }
        }
        public int MAX_CAPACITY {
            get
            {
                int i;
                if (int.TryParse(txtMax_Capacity.Text, out i))
                    return i;
                else
                    return -1;
            }            
                
            set
            {
                string text = new string(value.ToString().ToCharArray().Where(c => char.IsDigit(c)).ToArray());
                int i;
                if (int.TryParse(text,out i))
                    txtMax_Capacity.Text = i.ToString();
                else
                    txtMax_Capacity.Text = "0";
            }
            
        }
        #endregion

        public MaintainBedPage()
        {
            InitializeComponent();

            InitializeController();
        }

        private void InitializeController()
        {
            _controller = new MaintainBedController(this);
            _controller.LoadView();
            //btnAdd.IsEnabled = true;
            //btnEdit.IsEnabled = false;
            //btnRemove.IsEnabled = false;
            SetbtnEditRemoveIsEnabled(false);
        }

        private void SetbtnEditRemoveIsEnabled(bool flag, bool btnAddflag = true)
        {
            btnEdit.IsEnabled = flag;
            btnRemove.IsEnabled = flag;
            btnAdd.IsEnabled = btnAddflag ? !flag : flag;
        }
        #region Events raised back to controller

        private void grdList_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdList.SelectedItems.Count > 0)
            {
                dynamic item = grdList.SelectedItem;
                _controller.SelectedModelChanged(item.ID_PK);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //btnEdit.IsEnabled = false;
            //btnRemove.IsEnabled = false;
            //btnAdd.IsEnabled = false;
            SetbtnEditRemoveIsEnabled(false, false);
            _controller.AddNew();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _controller.Revert();
            //btnEdit.IsEnabled = false;
            //btnRemove.IsEnabled = false;
            //btnAdd.IsEnabled = true;
            SetbtnEditRemoveIsEnabled(false);
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //btnEdit.IsEnabled = false;
            //btnRemove.IsEnabled = false;
            //btnAdd.IsEnabled = false;
            SetbtnEditRemoveIsEnabled(false, false);
            SetViewButtonIsEnabled(true);
            _controller.Edit();  
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            _controller.Save();
            //btnEdit.IsEnabled = false;
            //btnRemove.IsEnabled = false;
            //btnAdd.IsEnabled = true;
            SetbtnEditRemoveIsEnabled(false);
        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _controller.Remove();
            //btnEdit.IsEnabled = false;
            //btnRemove.IsEnabled = false;
            //btnAdd.IsEnabled = true;
            SetbtnEditRemoveIsEnabled(false);
        }

        #endregion

        # region IMaintainBedView


        public void Add_To_Grid(Abstract_Model obj)
        {
            grdList.Items.Add((BED_Model)obj);
        }
        public void ClearField()
        {
            txtGUID.Text = "";
            txtDescription.Text = string.Empty;
            txtMax_Capacity.Text = "";
        }
        public void Clear_Grid()
        {
            grdList.Items.Clear();
        }

        public Guid? GetSelectedID()
        {
            if (grdList.SelectedIndex > 0)
            {
                dynamic obj = grdList.SelectedItem;
                return obj.ID_PK;
            }
            else
                return null;
        }

        public void Remove_From_Grid(Abstract_Model obj)
        {
            Abstract_Model rowToRemove = null;

            foreach (Abstract_Model row in grdList.Items)
            {
                if (row.ID_PK == obj.ID_PK )
                {
                    rowToRemove = row;
                    break;
                }
            }

            if (rowToRemove != null)
            {
                grdList.Items.Remove(rowToRemove);
                grdList.Focus();
            }
        }

        public void SetSelectedInGrid(Abstract_Model obj)
        {
            for (int i = 0; i < grdList.Items.Count; i++)
            {
                dynamic item = grdList.Items[i];
                if (item.ID_PK == obj.ID_PK)
                {
                    grdList.SelectedIndex = i;
                    SetbtnEditRemoveIsEnabled(true, false);
                    //btnEdit.IsEnabled = true;
                    //btnRemove.IsEnabled = true;
                    SetbtnEditRemoveIsEnabled(true, false);
                    break;
                }
            }
        }

        public void Update_Grid(Abstract_Model obj)
        {
            dynamic rowToUpdate = null;

            foreach (Abstract_Model row in grdList.Items)
            {
                if (row.ID_PK == obj.ID_PK)
                {
                    rowToUpdate = row;
                    break;
                }
            }

            if (rowToUpdate != null)
            {
                rowToUpdate.ID_PK = obj.ID_PK;
                rowToUpdate.DESCRIPTION = ((BED_Model)obj).DESCRIPTION;
                rowToUpdate.MAX_CAPACITY = ((BED_Model)obj).MAX_CAPACITY;
                grdList.Items.Refresh();
            }
        }



        public void SetViewButtonIsEnabled(Boolean flag)
        {
            btnOK.IsEnabled = flag;
            btnCancel.IsEnabled = flag;

            txtDescription.IsEnabled = flag;
            txtMax_Capacity.IsEnabled = flag;

        }

        #endregion


    }


}
