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
using System.Collections;

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
        public Guid BED_FK { get ; set ; }
        public Guid ID_PK { get; set; }
        public int NUM
        {
            get
            {
                int i;
                if (int.TryParse(txtCount.Text, out i))
                    return i;
                else
                    return -1;
            }

            set
            {
                string text = new string(value.ToString().ToCharArray().Where(c => char.IsDigit(c)).ToArray());
                int i;
                if (int.TryParse(text, out i))
                    txtCount.Text = i.ToString();
                else
                    txtCount.Text = "0";
            }
        }

        #endregion

        public string DESCRIPTION
        {
            get => txtRoomDescription.Text;
            set { txtRoomDescription.Text = value; }
        }

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
            //throw new NotImplementedException();
            _controller.Revert();
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            _controller.Save();
        }
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void grdList_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdList.SelectedItems.Count > 0)
            {
                int i = grdList.SelectedIndex;
                dynamic item = grdList.Items[i];
                _controller.SelectedModelChanged(item.MODEL.DESCRIPTION);
            }
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
            txtRoomDescription.Text = string.Empty;
            txtCount.Text = string.Empty;
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
            for (int i = 0; i < grdList.Items.Count; i++)
            {
                dynamic item = grdList.Items[i];
                if (item.MODEL.DESCRIPTION == ((BED_SETTING_Model)obj).DESCRIPTION)
                {
                    grdList.SelectedIndex = i;

                    SetViewButtonIsEnabled(true);
                    break;
                }
            }
        }

        public void SetViewButtonIsEnabled(bool flag)
        {
            btnCancel.IsEnabled = flag;
            btnOK.IsEnabled = flag;
            txtCount.IsEnabled = flag;
        }

        public void Update_Grid(Abstract_Model obj)
        {
            //throw new NotImplementedException();
            //dynamic rowToUpdate = null;

            for(int i = 0; i < grdList.Items.Count;i++)
            {
                dynamic row = grdList.Items[i];
                if (row.DESCRIPTION == ((BED_SETTING_Model)obj).DESCRIPTION)
                {
                    //rowToUpdate = row;

                    grdList.Items[i] = new {
                        DESCRIPTION = ((BED_SETTING_Model)obj).DESCRIPTION,
                        NUM = ((BED_SETTING_Model)obj).NUM,
                        MODEL = obj
                    };

                    break;
                }
            }
            /*
            foreach (dynamic row in grdList.Items)
            {
                if (row.DESCRIPTION == ((BED_SETTING_Model)obj).DESCRIPTION)
                {
                    rowToUpdate = row;
                    break;
                }
            }
            
            if (rowToUpdate != null)
            {
                //rowToUpdate.NUM = ((BED_SETTING_Model)obj).NUM;
                //rowToUpdate.DESCRIPTION = ((BED_SETTING_Model)obj).DESCRIPTION;
                //rowToUpdate.MODEL = obj;
                rowToUpdate.NUM = rowToUpdate.MODEL.NUM;
                rowToUpdate.DESCRIPTION = rowToUpdate.MODEL.DESCRIPTION;
                grdList.Items.Refresh();
            }
            */
        }
        #endregion
    }
}
