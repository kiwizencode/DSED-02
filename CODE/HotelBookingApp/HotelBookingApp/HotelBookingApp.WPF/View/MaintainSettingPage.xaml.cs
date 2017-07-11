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
        private MaintainBedController _controller;
        public MaintainSettingPage()
        {
            InitializeController();
        }

        private void InitializeController()
        {
            _controller = new MaintainBedController(this);
            _controller.LoadView();
        }

        public string DESCRIPTION { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid ID_PK { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add_To_Grid(Abstract_Model obj)
        {
            throw new NotImplementedException();
        }

        public void ClearField()
        {
            throw new NotImplementedException();
        }

        public void Clear_Grid()
        {
            throw new NotImplementedException();
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

        public void SetViewButtonIsEnabled(bool flag = true)
        {
            throw new NotImplementedException();
        }

        public void Update_Grid(Abstract_Model obj)
        {
            throw new NotImplementedException();
        }
    }
}
