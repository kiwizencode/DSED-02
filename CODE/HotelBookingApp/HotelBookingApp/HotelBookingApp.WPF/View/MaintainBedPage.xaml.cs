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

        private Guid _ID;
        public Guid ID_PK {
            get => _ID ;
            set {
                _ID = value;
                this.txtGUID.Text = _ID.ToString();
            }
        }
        public string DESCRIPTION {
            get => txtDescription.Text ;
            set => txtDescription.Text=value;
        }
        public int MAX_CAPACITY {
            get => int.Parse(txtMax_Capacity.Text);
            set => txtMax_Capacity.Text=value.ToString();
        }
        public bool CanModifyID { set => txtGUID.IsEnabled=value; }


        public MaintainBedPage()
        {
            InitializeComponent();

            InitializeController();
        }

        private void InitializeController()
        {
            this._controller = new MaintainBedController(this);
            _controller.LoadView();
        }


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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this._controller.Save();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        # region IMaintainBedView
        public void Add_To_Grid(ModelBaseClass obj)
        {
            this.grdList.Items.Add((BED)obj);
        }

        public void Clear_Grid()
        {
            this.grdList.Items.Clear();
        }

        public void Remove_From_Grid(ModelBaseClass obj)
        {
            BED rowToRemove = null;

            foreach (BED row in this.grdList.Items)
            {

                if (row.ID_PK == obj.ID_PK )
                {
                    rowToRemove = row;
                    break;
                }
            }

            if (rowToRemove != null)
            {
                this.grdList.Items.Remove(rowToRemove);
                this.grdList.Focus();
            }
        }

        public void SetSelectedInGrid(ModelBaseClass obj)
        {
            for (int i = 0; i < this.grdList.Items.Count; i++)
            {
                dynamic userdata = this.grdList.Items[i];
                if (userdata.ID_PK == obj.ID_PK)
                {
                    this.grdList.SelectedIndex = i;
                    break;
                }
            }
        }

        public void Update_Grid(ModelBaseClass obj)
        {
            BED rowToUpdate = null;

            foreach (BED row in this.grdList.Items)
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
                rowToUpdate.DESCRIPTION = ((BED)obj).DESCRIPTION;
                rowToUpdate.MAX_CAPACITY = ((BED)obj).MAX_CAPACITY;
                grdList.Items.Refresh();
            }
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


    }
}
