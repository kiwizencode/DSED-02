using HotelBookingApp.WPF.Controller;
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

namespace HotelBookingApp.WPF.View
{
    /// <summary>
    /// Interaction logic for MaintainBedSettingPage.xaml
    /// </summary>
    public partial class MaintainBedSettingPage : Page, IMaintainBedSettingView
    {
        private MaintainBedSettingController _controller;
        private IMaintainSettingView _parent_view;

        #region Implement IMaintainBedSettingView Interface code
        public Guid SETTING_FK { get; set; }
        public Guid BED_FK { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int NUM { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid ID_PK { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        public MaintainBedSettingPage(IMaintainSettingView view)
        {


            InitializeComponent();

            _parent_view = view;
            SETTING_FK = view.ID_PK;
            txtGUID.Text = view.ID_PK.ToString();
            txtDescription.Text = view.DESCRIPTION;


            InitializeController();
        }

        private void InitializeController()
        {
            _controller = new MaintainBedSettingController(this);
            _controller.LoadView();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void grdList_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #region Implement IMaintainBedSettingView Interface code
        public void Add_To_Grid(Abstract_Model obj)
        {
            //grdList.Items.Add((BED_SETTING_Model)obj);
            grdList.Items.Add( new {
                DESCRIPTION = ((BED_SETTING_Model)obj).DESCRIPTION,
                NUM= ((BED_SETTING_Model)obj).NUM,
                MODEL=obj
            });

        }

        public void ClearField()
        {
            throw new NotImplementedException();
        }

        public void Clear_Grid()
        {
            grdList.Items.Clear();
        }

        public Guid? GetSelectedID()
        {
            throw new NotImplementedException();
        }

        public void Remove_From_Grid(Abstract_Model obj)
        {
            throw new NotImplementedException();
        }

        public void SetSelectedInGrid(Abstract_Model obj)
        {
            throw new NotImplementedException();
        }

        public void SetViewButtonIsEnabled(bool flag)
        {
            throw new NotImplementedException();
        }

        public void Update_Grid(Abstract_Model obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
