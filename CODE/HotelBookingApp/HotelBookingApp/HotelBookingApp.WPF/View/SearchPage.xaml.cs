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
    /// Interaction logic for Page.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        const string DOUBLE_BED = "DOUBLE BED";
        const string SINGLE_BED = "SINGLE BED";
        public SearchPage()
        {
            InitializeComponent();
            InitializeGUIControls();

            InitializeDummyData();
        }

        private void InitializeDummyData()
        {
            IList rooms = new ArrayList();
            rooms.Add(new RoomSetting(1, DOUBLE_BED, 1100f, 2, 1));
            rooms.Add(new RoomSetting(1, SINGLE_BED, 850f, 1, 1));

            rooms.Add(new RoomSetting(2, DOUBLE_BED, 1100f, 2, 2));

            rooms.Add(new RoomSetting(3, DOUBLE_BED, 1100f, 2, 1));
            rooms.Add(new RoomSetting(3, SINGLE_BED, 850f, 1, 1));

            rooms.Add(new RoomSetting(4, DOUBLE_BED, 1100f, 2, 2));

            rooms.Add(new RoomSetting(5, DOUBLE_BED, 850f, 1, 4));

            rooms.Add(new RoomSetting(6, SINGLE_BED, 850f, 1, 5));

            MainList.ItemsSource = rooms;

        }

        private void InitializeGUIControls()
        {
            NoOfGuest.Text = "";
            GuestNotAllocated.Text = "";
            CustomerName.Text = "";
            SelectCalendar.SelectedDate = DateTime.Now;
        }
        
        private void SelectCalender_Changed(object sender, SelectionChangedEventArgs e)
        {
            Calendar obj = sender as Calendar;
            int count = obj.SelectedDates.Count;
            if (count > 0)
            {

                SelectStartDate.SelectedDate = obj.SelectedDates[0];
                SelectEndDate.SelectedDate = obj.SelectedDates[count-1];
            }
        }
    }
}
