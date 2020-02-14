

using System;
using System.Windows;
using System.Windows.Threading;

namespace Flakesnow
{
    /// <summary>
    /// Interaction logic for Timer.xaml
    /// </summary>
    public partial class Timer : Window
    {
        public Timer()
        {
            InitializeComponent();
        }

        private int seconds = 0;
        private int minutes = 0;
        private int hours = 0;
        bool isPause = false;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private void dtTicker(object sender, EventArgs e)
        {
            if (!isPause)
            {
                if (hours > 0)
                {
                    TimeLabel.Content = $"{hours}:{minutes}:{seconds}";
                }
                else
                {
                    TimeLabel.Content = $"{minutes}:{seconds}";
                }
                seconds++;
                if (seconds >= 60)
                {
                    minutes++;
                    seconds = 0;
                }
                if (minutes >= 60)
                {
                    hours++;
                    minutes = 0;
                }
            }
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            TimeLabel.Content = "0:0";
            seconds = 0;
            minutes = 0;
            hours = 0;

        }

        private void Alarm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            if (!isPause)
            {
                isPause = true;
                PauseButton.Content = "Continue";
            }
            else if (isPause)
            {
                isPause = false;
                PauseButton.Content = "Pause";
            }
        }
    
}
}
