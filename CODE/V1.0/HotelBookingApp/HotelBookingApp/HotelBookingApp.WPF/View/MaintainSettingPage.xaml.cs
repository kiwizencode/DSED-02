using System;
using System.Collections.Generic;
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
    /// Interaction logic for MaintainSettingPage.xaml
    /// </summary>
    public partial class MaintainSettingPage : Page , IMaintainSettingView
    {
        // controller for Maintain Setting View
        private MaintainSettingController _controller;

        private Guid _ID;
        public Guid ID_PK
        {
            get => _ID;
            set
            {
                _ID = value;
                txtGUID.Text = _ID.ToString();
            }
        }

        public string DESCRIPTION
        {
            get => txtDescription.Text;
            set => txtDescription.Text = value.TrimEnd();
        }

        public MaintainSettingPage()
        {
            InitializeComponent();

            InitializeController();
        }

        private void InitializeController()
        {
            _controller = new MaintainSettingController(this);
            _controller.LoadView();
        }

        private void SetButtonAddIsEnabled(bool flag)
        {
            // set Add/Edit/Remove button isEnable 
            btnAdd.IsEnabled = flag;
            btnEdit.IsEnabled = !flag;
            btnRemove.IsEnabled = !flag;
        }

        # region IMaintainSettingView

        public void Add_To_Grid(Abstract_Model obj)
        {
            grdList.Items.Add(obj);
        }

        public void ClearField()
        {
            txtGUID.Text = "";
            txtDescription.Text = string.Empty;
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
                if (row.ID_PK == obj.ID_PK)
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
                    break;
                }
            }
        }

        public void SetViewButtonIsEnabled(bool flag = true)
        {
            btnOK.IsEnabled = !flag;
            btnCancel.IsEnabled = !flag;

            txtDescription.IsEnabled = !flag;

            btnAdd.IsEnabled = flag;
            btnRemove.IsEnabled = flag;
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
                rowToUpdate.DESCRIPTION = ((SETTING_Model)obj).DESCRIPTION;
                grdList.Items.Refresh();
            }
        }
        #endregion

        #region Events raised back to controller

        private void grdList_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdList.SelectedItems.Count > 0)
            {
                dynamic item = grdList.SelectedItem;
                _controller.SelectedModelChanged(item.ID_PK);
            }
        }


        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        #endregion

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
