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

namespace HotelBookingApp.WPF.View
{
    /// <summary>
    /// Interaction logic for Page.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            InitializeGUIControls();
        }

        private void InitializeGUIControls()
        {
            NoOfGuest.Text = "";
            GuestNotAllocated.Text = "";
            SelectCalendar.SelectedDate = DateTime.Now;
        }

        
        private void SelectStartDate_Changed(object sender, SelectionChangedEventArgs e)
        {
            DatePicker picker = sender as DatePicker;
            //SelectCalendar.DisplayDateStart = picker.SelectedDate;
        }

        private void SelectEndDate_Changed(object sender, SelectionChangedEventArgs e)
        {
            DatePicker picker = sender as DatePicker;
            //SelectCalendar.DisplayDateEnd = picker.SelectedDate;
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
