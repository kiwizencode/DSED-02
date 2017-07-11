﻿using System;
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

        private Guid _ID;
        public Guid ID_PK {
            get => _ID ;
            set {
                _ID = value;
                txtGUID.Text = _ID.ToString();
            }
        }
        public string DESCRIPTION {
            get => txtDescription.Text ;
            set => txtDescription.Text=value.TrimEnd();
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
        //public bool CanModifyID { set => txtGUID.IsEnabled=value; }

        public MaintainBedPage()
        {
            InitializeComponent();

            InitializeController();
        }

        private void InitializeController()
        {
            _controller = new MaintainBedController(this);
            _controller.LoadView();
        }


        #region Events raised back to controller

        private void grdList_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdList.SelectedItems.Count > 0)
            {
                dynamic bed = grdList.SelectedItem;
                _controller.SelectedModelChanged(bed.ID_PK);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _controller.AddNew();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _controller.Remove();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            _controller.Save();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _controller.Revert();
        }

        #endregion

        # region IMaintainBedView


        public void Add_To_Grid(Abstract_Model obj)
        {
            grdList.Items.Add((BED_Model)obj);
        }

        public void Clear_Grid()
        {
            grdList.Items.Clear();
        }

        public void Remove_From_Grid(Abstract_Model obj)
        {
            BED_Model rowToRemove = null;

            foreach (BED_Model row in grdList.Items)
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
                dynamic userdata = grdList.Items[i];
                if (userdata.ID_PK == obj.ID_PK)
                {
                    grdList.SelectedIndex = i;
                    break;
                }
            }
        }

        public void Update_Grid(Abstract_Model obj)
        {
            BED_Model rowToUpdate = null;

            foreach (BED_Model row in grdList.Items)
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

        public void ClearField()
        {
            txtGUID.Text = "" ;
            txtDescription.Text = string.Empty;
            txtMax_Capacity.Text = "";

            SetViewButtonIsEnabled();
        }

        public void SetViewButtonIsEnabled()
        {
            btnOK.IsEnabled = !btnOK.IsEnabled;
            btnCancel.IsEnabled = !btnCancel.IsEnabled;

            txtDescription.IsEnabled = !txtDescription.IsEnabled;
            txtMax_Capacity.IsEnabled = !txtMax_Capacity.IsEnabled;

            btnAdd.IsEnabled = !btnAdd.IsEnabled;
            btnRemove.IsEnabled = !btnRemove.IsEnabled;
        }
        #endregion


    }


}
