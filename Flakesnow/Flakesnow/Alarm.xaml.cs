using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Flakesnow
{
    /// <summary>
    /// Interaction logic for Alarm.xaml
    /// </summary>
    public partial class Alarm : Window
    {
        public Alarm()
        {
            InitializeComponent();
        }

        string alarmTime = ""; //Alarm time
        bool AlarmOn = false; //Checks if Alarm is on
        bool alarmSound = false;
        string timeNow = DateTime.Now.ToString("HH.mm");


        private void Window_Loaded(object sender, RoutedEventArgs e) //Timer who updates timeNow string
        {
            Label1.Content = DateTime.Now.ToString("HH.mm.ss");
            Label2.Content = DateTime.Now.ToString("dddd, d MMMM yyyy"); //Shows current day, month and year
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }
        SoundPlayer snd = new SoundPlayer(new Uri("Resources/alarmsound.wav", UriKind.Relative).ToString());
        private void dtTicker(object sender, EventArgs e)
        {
            Label1.Content = DateTime.Now.ToString("HH.mm.ss"); //Updates time label every second
            Label2.Content = DateTime.Now.ToString("dddd, d MMMM yyyy"); //Shows current day, month and year
            timeNow = DateTime.Now.ToString("HH.mm");

            if (timeNow.Equals(alarmTime) && AlarmOn == true)
            {
                Topmost = true;
                alarmSound = true;
                snd.Load();
            }
            if (alarmSound == true)
            {
                snd.Play();
            }
        }

        private void AlarmButton_Click(object sender, RoutedEventArgs e)
        {
            alarmSound = false;
            snd.Stop();
            Topmost = false;
            string hours = HourBox.SelectionBoxItem.ToString();
            string minutes = MinuteBox.SelectionBoxItem.ToString();
            alarmTime = ($"{hours}.{minutes}");
            if (AlarmOn == false)
            {
                AlarmButton.Content = "Stop alarm";
                AlarmOn = true;
                HourBox.IsReadOnly = true;
                MinuteBox.IsReadOnly = true;
                AlarmTime.Content = ($"Alarm set for: {alarmTime}");
            }
            else if (AlarmOn == true)
            {
                AlarmButton.Content = "Set alarm";
                AlarmOn = false;
                HourBox.IsReadOnly = false;
                MinuteBox.IsReadOnly = false;
                AlarmTime.Content = ("Set alarm time");
            }



        }
    }
}