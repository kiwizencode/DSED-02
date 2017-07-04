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
    /// Interaction logic for MaintainBedPage.xaml
    /// </summary>
    public partial class MaintainBedPage : Page, IMaintainBedView
    {
        private MaintainBedController _controller;

        public MaintainBedPage()
        {
            InitializeComponent();
        }

        public Guid ID_PK { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DESCRIPTION { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MAX_CAPACITY { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool CanModifyID { set => throw new NotImplementedException(); }


        #region Events raised back to controller

        private void grdList_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.grdList.SelectedItems.Count > 0)
            //    this._controller.SelectedUserChanged(this.grdUsers.SelectedItems[0].Text);
            {
                dynamic bed = this.grdList.SelectedItem;
                this._controller.SelectedUserChanged(bed.ID_PK);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this._controller.AddNew();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            this._controller.Remove();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        # region IMaintainBedView
        public void Add_To_Grid(BED bed)
        {
            throw new NotImplementedException();
        }

        public void clear_Grid()
        {
            throw new NotImplementedException();
        }

        public void Remove_From_Grid(BED bed)
        {
            BED rowToRemove = null;

            foreach (BED row in this.grdList.Items)
            {

                if (row.ID_PK == bed.ID_PK)
                {
                    rowToRemove = row;
                }
            }

            if (rowToRemove != null)
            {
                this.grdList.Items.Remove(rowToRemove);
                this.grdList.Focus();
            }
        }

        public void SetSelectedInGrid(BED bed)
        {
            for (int i = 0; i < this.grdList.Items.Count; i++)
            {
                dynamic userdata = this.grdList.Items[i];
                if (userdata.ID_PK == bed.ID_PK)
                {
                    this.grdList.SelectedIndex = i;
                    break;
                }
            }
        }

        public void Update_Grid(BED bed)
        {
            throw new NotImplementedException();
        }


        public Guid? GetSelectedID()
        {
            if (this.grdList.SelectedIndex > 0)
            {
                dynamic obj = this.grdList.SelectedItem;
                return obj.ID_PK;
            }
            else
                return null;
        }

        #endregion

        #region code not implemented
        public void Set_Controller(MaintainBedController controller)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
