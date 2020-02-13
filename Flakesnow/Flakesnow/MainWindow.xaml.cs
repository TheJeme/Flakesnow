using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Diagnostics;
using Flakesnow.Properties;
using System.Windows.Threading;

namespace Flakesnow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();

            txtTimeTemps.Add(txtTimeTemp1);
            txtTimeTemps.Add(txtTimeTemp2);
            txtTimeTemps.Add(txtTimeTemp3);
            txtTimeTemps.Add(txtTimeTemp4);
            txtTimeTemps.Add(txtTimeTemp5);
            txtTimeTemps.Add(txtTimeTemp6);
            txtTimeTemps.Add(txtTimeTemp7);
            txtTimeTemps.Add(txtTimeTemp8);

            txtTimeSymbols.Add(txtTimeSymbol1);
            txtTimeSymbols.Add(txtTimeSymbol2);
            txtTimeSymbols.Add(txtTimeSymbol3);
            txtTimeSymbols.Add(txtTimeSymbol4);
            txtTimeSymbols.Add(txtTimeSymbol5);
            txtTimeSymbols.Add(txtTimeSymbol6);
            txtTimeSymbols.Add(txtTimeSymbol7);
            txtTimeSymbols.Add(txtTimeSymbol8);

            DateTime timeNow = DateTime.Now;
            int hourNow = timeNow.Hour;

            if (hourNow >= 5 && hourNow < 12)
                txtGood.Content = "Good morning " + Settings.Default["Name"];
            else if (hourNow >= 12 && hourNow < 18)
                txtGood.Content = "Good afternoon " + Settings.Default["Name"];
            else if (hourNow >= 18 || hourNow < 5)
                txtGood.Content = "Good evening " + Settings.Default["Name"];
            else
                txtGood.Content = hourNow;
        }



        const string weatherApiKey = "e238f11ff8bb1b9c19d97a11ba1b3c17";

        const string CurrentUrl =
            "http://api.openweathermap.org/data/2.5/weather?" +
            "q=@LOC@&mode=xml&units=@unit@&APPID=" + weatherApiKey;

        const string ForecastUrl =
            "http://api.openweathermap.org/data/2.5/forecast?" +
            "q=@LOC@&mode=xml&units=@unit@&APPID=" + weatherApiKey;

        string unitSystem = "metric";

        List<TextBlock> txtTimeTemps = new List<TextBlock>();
        List<Image> txtTimeSymbols = new List<Image>();


        private void Window_StateChanged(object sender, EventArgs e)
        {/*
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }*/
        }



        private void quit_Button(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void hideWindow_Button(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }





        private void CelsiusButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CelsiusButton.Background = Brushes.White;
            FahrenheitButton.Background = Brushes.LightGray;

            Settings.Default["celsiusSelected"] = true;
            unitSystem = "metric";
        }

        private void FahrenheitButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CelsiusButton.Background = Brushes.LightGray;
            FahrenheitButton.Background = Brushes.White;

            Settings.Default["celsiusSelected"] = false;
            unitSystem = "imperial";
        }
        
        private void border1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HideGrids();
            HomeGrid.Visibility = Visibility.Visible;

            DateTime timeNow = DateTime.Now;
            int hourNow = timeNow.Hour;

            if (hourNow >= 5 && hourNow < 12)
                txtGood.Content = "Good morning " + Settings.Default["Name"];
            else if (hourNow >= 12 && hourNow < 18)
                txtGood.Content = "Good afternoon " + Settings.Default["Name"];
            else if (hourNow >= 18 || hourNow < 5)
                txtGood.Content = "Good evening " + Settings.Default["Name"];
            else
                txtGood.Content = hourNow;
        }

        private void border2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HideGrids();
            TimerGrid.Visibility = Visibility.Visible;

            if(Convert.ToBoolean(Settings.Default["Timer1Active"]) == true)
            {
                Timer1.Visibility = Visibility.Visible;
                Timer1Title.Content = Settings.Default["Timer1Title"];
            }
            if (Convert.ToBoolean(Settings.Default["Timer2Active"]) == true)
            {
                Timer2.Visibility = Visibility.Visible;
                Timer2Title.Content = Settings.Default["Timer2Title"];
            }
            if (Convert.ToBoolean(Settings.Default["Timer3Active"]) == true)
            {
                Timer3.Visibility = Visibility.Visible;
                Timer3Title.Content = Settings.Default["Timer3Title"];
            }
            if (Convert.ToBoolean(Settings.Default["Timer4Active"]) == true)
            {
                Timer4.Visibility = Visibility.Visible;
                Timer4Title.Content = Settings.Default["Timer4Title"];
            }
            if (Convert.ToBoolean(Settings.Default["Timer5Active"]) == true)
            {
                Timer5.Visibility = Visibility.Visible;
                Timer5Title.Content = Settings.Default["Timer5Title"];
            }
            if (Convert.ToBoolean(Settings.Default["Timer6Active"]) == true)
            {
                Timer6.Visibility = Visibility.Visible;
                Timer6Title.Content = Settings.Default["Timer6Title"];
            }
        }

        private void border3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HideGrids();
            RemindersGrid.Visibility = Visibility.Visible;

            if (Convert.ToBoolean(Settings.Default["Reminder1Active"]) == true)
            {
                Reminder1.Visibility = Visibility.Visible;
            }
            if (Convert.ToBoolean(Settings.Default["Reminder2Active"]) == true)
            {
                Reminder2.Visibility = Visibility.Visible;
            }
            if (Convert.ToBoolean(Settings.Default["Reminder3Active"]) == true)
            {
                Reminder3.Visibility = Visibility.Visible;
            }
            if (Convert.ToBoolean(Settings.Default["Reminder4Active"]) == true)
            {
                Reminder4.Visibility = Visibility.Visible;
            }
            if (Convert.ToBoolean(Settings.Default["Reminder5Active"]) == true)
            {
                Reminder5.Visibility = Visibility.Visible;
            }
            if (Convert.ToBoolean(Settings.Default["Reminder6Active"]) == true)
            {
                Reminder6.Visibility = Visibility.Visible;
            }


            Reminder1Text.Text = Settings.Default["Reminder1Text"].ToString();
            Reminder2Text.Text = Settings.Default["Reminder2Text"].ToString();
            Reminder3Text.Text = Settings.Default["Reminder3Text"].ToString();
            Reminder4Text.Text = Settings.Default["Reminder4Text"].ToString();
            Reminder5Text.Text = Settings.Default["Reminder5Text"].ToString();
            Reminder6Text.Text = Settings.Default["Reminder6Text"].ToString();

            Reminder1Title.Text = Settings.Default["Reminder1Title"].ToString();
            Reminder2Title.Text = Settings.Default["Reminder2Title"].ToString();
            Reminder3Title.Text = Settings.Default["Reminder3Title"].ToString();
            Reminder4Title.Text = Settings.Default["Reminder4Title"].ToString();
            Reminder5Title.Text = Settings.Default["Reminder5Title"].ToString();
            Reminder6Title.Text = Settings.Default["Reminder6Title"].ToString();
        }

        private void border4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            HideGrids();
            WeatherGrid.Visibility = Visibility.Visible;

            if (Convert.ToBoolean(Settings.Default["celsiusSelected"]))
            {
                txtDegrees.Content += "°C";
                unitSystem = "metric";
                CelsiusButton.Background = Brushes.White;
                FahrenheitButton.Background = Brushes.LightGray;
            }
            else
            {
                txtDegrees.Content += "°F";
                unitSystem = "imperial";
                CelsiusButton.Background = Brushes.LightGray;
                FahrenheitButton.Background = Brushes.White;
            }


            
            // Compose the query URL.
            string url = ForecastUrl.Replace("@LOC@", Settings.Default["Location"].ToString());
            url = url.Replace("@unit@", unitSystem);
            // url = url.Replace("@QUERY@", QueryCodes[cboQuery.SelectedIndex]);

            // Create a web client.
            using (WebClient client = new WebClient())
            {
                // Get the response string from the URL.
                try
                {
                    DisplayForecast(client.DownloadString(url));
                }
                catch (WebException ex)
                {
                    MessageBox.Show("Unknown weberror\n" + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unknown error\n" + ex.Message);
                }
            }
            
        }

        private void border5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HideGrids();
            ConfigureGrid.Visibility = Visibility.Visible;

            txtName.Text = Settings.Default["Name"].ToString();
            txtLocation.Text = Settings.Default["Location"].ToString();
        }

        private void AddNewReminder_Button(object sender, MouseButtonEventArgs e)
        {
            if (Reminder1.Visibility == Visibility.Collapsed)
            {
                Reminder1.Visibility = Visibility.Visible;
                Settings.Default["Reminder1Active"] = true;
                Settings.Default.Save();
                Reminder1Text.Text = "Type here...";
                Reminder1Title.Text = "Reminder";
            }
            else if (Reminder2.Visibility == Visibility.Collapsed)
            {
                Reminder2.Visibility = Visibility.Visible;
                Settings.Default["Reminder2Active"] = true;
                Settings.Default.Save();
                Reminder2Text.Text = "Type here...";
                Reminder2Title.Text = "Reminder";
            }
            else if (Reminder3.Visibility == Visibility.Collapsed)
            {
                Reminder3.Visibility = Visibility.Visible;
                Settings.Default["Reminder3Active"] = true;
                Settings.Default.Save();
                Reminder3Text.Text = "Type here...";
                Reminder3Title.Text = "Reminder";
            }
            else if (Reminder4.Visibility == Visibility.Collapsed)
            {
                Reminder4.Visibility = Visibility.Visible;
                Settings.Default["Reminder4Active"] = true;
                Settings.Default.Save();
                Reminder4Text.Text = "Type here...";
                Reminder4Title.Text = "Reminder";
            }
            else if (Reminder5.Visibility == Visibility.Collapsed)
            {
                Reminder5.Visibility = Visibility.Visible;
                Settings.Default["Reminder5Active"] = true;
                Settings.Default.Save();
                Reminder5Text.Text = "Type here...";
                Reminder5Title.Text = "Reminder";
            }
            else if (Reminder6.Visibility == Visibility.Collapsed)
            {
                Reminder6.Visibility = Visibility.Visible;
                Settings.Default["Reminder6Active"] = true;
                Settings.Default.Save();
                Reminder6Text.Text = "Type here...";
                Reminder6Title.Text = "Reminder";
            }
        }
        

        private void DeleteReminder1_Button(object sender, MouseButtonEventArgs e)
        {
            Reminder1.Visibility = Visibility.Collapsed;
            Settings.Default["Reminder1Active"] = false;
            Settings.Default["changedReminder1Text"] = false;
            Settings.Default["changedReminder1Title"] = false;
            Settings.Default.Save();
        }

        private void DeleteReminder2_Button(object sender, MouseButtonEventArgs e)
        {
            Reminder2.Visibility = Visibility.Collapsed;
            Settings.Default["Reminder2Active"] = false;
            Settings.Default["changedReminder2Text"] = false;
            Settings.Default["changedReminder2Title"] = false;
            Settings.Default.Save();
        }

        private void DeleteReminder3_Button(object sender, MouseButtonEventArgs e)
        {
            Reminder3.Visibility = Visibility.Collapsed;
            Settings.Default["Reminder3Active"] = false;
            Settings.Default["changedReminder3Text"] = false;
            Settings.Default["changedReminder3Title"] = false;
            Settings.Default.Save();
        }

        private void DeleteReminder4_Button(object sender, MouseButtonEventArgs e)
        {
            Reminder4.Visibility = Visibility.Collapsed;
            Settings.Default["Reminder4Active"] = false;
            Settings.Default["changedReminder4Text"] = false;
            Settings.Default["changedReminder4Title"] = false;
            Settings.Default.Save();
        }

        private void DeleteReminder5_Button(object sender, MouseButtonEventArgs e)
        {
            Reminder5.Visibility = Visibility.Collapsed;
            Settings.Default["Reminder5Active"] = false;
            Settings.Default["changedReminder5Text"] = false;
            Settings.Default["changedReminder5Title"] = false;
            Settings.Default.Save();
        }

        private void DeleteReminder6_Button(object sender, MouseButtonEventArgs e)
        {
            Reminder6.Visibility = Visibility.Collapsed;
            Settings.Default["Reminder6Active"] = false;
            Settings.Default["changedReminder6Text"] = false;
            Settings.Default["changedReminder6Title"] = false;
            Settings.Default.Save();
        }

        private void Reminder1Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!Convert.ToBoolean(Settings.Default["changedReminder1Title"]))
            {
                Reminder1Title.Text = "";
                Settings.Default["changedReminder1Title"] = true;
            }
        }

        private void Reminder1Text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!Convert.ToBoolean(Settings.Default["changedReminder1Text"]))
            {
                Reminder1Text.Text = "";
                Settings.Default["changedReminder1Text"] = true;
            }
        }

        private void Reminder2Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!Convert.ToBoolean(Settings.Default["changedReminder2Title"]))
            {
                Reminder2Title.Text = "";
                Settings.Default["changedReminder2Title"] = true;
            }
        }

        private void Reminder2Text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!Convert.ToBoolean(Settings.Default["changedReminder2Text"]))
            {
                Reminder2Text.Text = "";
                Settings.Default["changedReminder2Text"] = true;
            }
        }

        private void Reminder3Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!Convert.ToBoolean(Settings.Default["changedReminder3Title"]))
            {
                Reminder3Title.Text = "";
                Settings.Default["changedReminder3Title"] = true;
            }
        }

        private void Reminder3Text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!Convert.ToBoolean(Settings.Default["changedReminder3Text"]))
            {
                Reminder3Text.Text = "";
                Settings.Default["changedReminder3Text"] = true;
            }
        }

        private void Reminder4Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!Convert.ToBoolean(Settings.Default["changedReminder4Title"]))
            {
                Reminder4Title.Text = "";
                Settings.Default["changedReminder4Title"] = true;
            }
        }

        private void Reminder4Text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!Convert.ToBoolean(Settings.Default["changedReminder4Text"]))
            {
                Reminder4Text.Text = "";
                Settings.Default["changedReminder4Text"] = true;
            }
        }

        private void Reminder5Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!Convert.ToBoolean(Settings.Default["changedReminder5Title"]))
            {
                Reminder5Title.Text = "";
                Settings.Default["changedReminder5Title"] = true;
            }
        }

        private void Reminder5Text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!Convert.ToBoolean(Settings.Default["changedReminder5Text"]))
            {
                Reminder5Text.Text = "";
                Settings.Default["changedReminder5Text"] = true;
            }
        }

        private void Reminder6Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!Convert.ToBoolean(Settings.Default["changedReminder6Title"]))
            {
                Reminder6Title.Text = "";
                Settings.Default["changedReminder6Title"] = true;
            }
        }

        private void Reminder6Text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!Convert.ToBoolean(Settings.Default["changedReminder6Text"]))
            {
                Reminder6Text.Text = "";
                Settings.Default["changedReminder6Text"] = true;
            }
        }

        private void DeleteTimer1_Button(object sender, RoutedEventArgs e)
        {
            Timer1.Visibility = Visibility.Collapsed;
            Settings.Default["Timer1Active"] = false;
        }
        private void DeleteTimer2_Button(object sender, RoutedEventArgs e)
        {
            Timer2.Visibility = Visibility.Collapsed;
            Settings.Default["Timer2Active"] = false;
        }
        private void DeleteTimer3_Button(object sender, RoutedEventArgs e)
        {
            Timer3.Visibility = Visibility.Collapsed;
            Settings.Default["Timer3Active"] = false;
        }
        private void DeleteTimer4_Button(object sender, RoutedEventArgs e)
        {
            Timer4.Visibility = Visibility.Collapsed;
            Settings.Default["Timer4Active"] = false;
        }
        private void DeleteTimer5_Button(object sender, RoutedEventArgs e)
        {
            Timer5.Visibility = Visibility.Collapsed;
            Settings.Default["Timer5Active"] = false;
        }
        private void DeleteTimer6_Button(object sender, RoutedEventArgs e)
        {
            Timer6.Visibility = Visibility.Collapsed;
            Settings.Default["Timer6Active"] = false;
        }

        private void dtTicker(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Settings.Default["Timer1Active"]) == true)
            {
                Timer1Days.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer1"]) - DateTime.Now).Days.ToString();
                Timer1Hours.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer1"]) - DateTime.Now).Hours.ToString();
                Timer1Minutes.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer1"]) - DateTime.Now).Minutes.ToString();
                Timer1Seconds.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer1"]) - DateTime.Now).Seconds.ToString();
            }
            if (Convert.ToBoolean(Settings.Default["Timer2Active"]) == true)
            {
                Timer2Days.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer2"]) - DateTime.Now).Days.ToString();
                Timer2Hours.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer2"]) - DateTime.Now).Hours.ToString();
                Timer2Minutes.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer2"]) - DateTime.Now).Minutes.ToString();
                Timer2Seconds.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer2"]) - DateTime.Now).Seconds.ToString();
            }
            if (Convert.ToBoolean(Settings.Default["Timer3Active"]) == true)
            {
                Timer3Days.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer3"]) - DateTime.Now).Days.ToString();
                Timer3Hours.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer3"]) - DateTime.Now).Hours.ToString();
                Timer3Minutes.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer3"]) - DateTime.Now).Minutes.ToString();
                Timer3Seconds.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer3"]) - DateTime.Now).Seconds.ToString();
            }
            if (Convert.ToBoolean(Settings.Default["Timer4Active"]) == true)
            {
                Timer4Days.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer4"]) - DateTime.Now).Days.ToString();
                Timer4Hours.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer4"]) - DateTime.Now).Hours.ToString();
                Timer4Minutes.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer4"]) - DateTime.Now).Minutes.ToString();
                Timer4Seconds.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer4"]) - DateTime.Now).Seconds.ToString();
            }
            if (Convert.ToBoolean(Settings.Default["Timer5Active"]) == true)
            {
                Timer5Days.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer5"]) - DateTime.Now).Days.ToString();
                Timer5Hours.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer5"]) - DateTime.Now).Hours.ToString();
                Timer5Minutes.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer5"]) - DateTime.Now).Minutes.ToString();
                Timer5Seconds.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer5"]) - DateTime.Now).Seconds.ToString();
            }
            if (Convert.ToBoolean(Settings.Default["Timer6Active"]) == true)
            {
                Timer6Days.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer6"]) - DateTime.Now).Days.ToString();
                Timer6Hours.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer6"]) - DateTime.Now).Hours.ToString();
                Timer6Minutes.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer6"]) - DateTime.Now).Minutes.ToString();
                Timer6Seconds.Content = (Convert.ToDateTime(Settings.Default["targetDateOnTimer6"]) - DateTime.Now).Seconds.ToString();
            }
        }

        private void txtName_TextChanged(object sender, RoutedEventArgs e)
        {
            Settings.Default["Name"] = txtName.Text;
            Settings.Default.Save();
        }

        private void txtLocation_TextChanged(object sender, RoutedEventArgs e)
        {
            Settings.Default["Location"] = txtLocation.Text;
            Settings.Default.Save();
        }

        private void ConfirmCreateNewTimer_Button(object sender, RoutedEventArgs e)
        {
            CreateNewTimer_Grid.Visibility = Visibility.Collapsed;

            int tempHours = Convert.ToInt16(HoursBox.SelectionBoxItem);
            int tempMinutes = Convert.ToInt16(MinutesBox.SelectionBoxItem);
            int tempSeconds = Convert.ToInt16(SecondsBox.SelectionBoxItem);

            DateTime targetDateOnTimer = DateTime.Now;

            if(Countdown_Stackpanel1.Visibility == Visibility.Visible)
            {
                targetDateOnTimer = DateTime.Now.AddHours(tempHours).AddMinutes(tempMinutes).AddSeconds(tempSeconds);
            }
            else if(CountTillDate_Stackpanel.Visibility == Visibility.Visible)
            {
                targetDateOnTimer = CountTillDate.SelectedDate.Value;
            }
            
            if (targetDateOnTimer.Hour >= 24)
            {
                targetDateOnTimer.AddHours(-24);
                targetDateOnTimer.AddDays(1);

            }
            else if (targetDateOnTimer.Hour >= 48)
            {
                targetDateOnTimer.AddHours(-48);
                targetDateOnTimer.AddDays(2);

            }

            if (Convert.ToBoolean(Settings.Default["Timer1Active"]) == false)
            {
                Settings.Default["targetDateOnTimer1"] = targetDateOnTimer;
                Timer1.Visibility = Visibility.Visible;
                Timer1Title.Content = Settings.Default["Timer1Title"] = CreateNewTimerTitle.Text;
                Settings.Default["Timer1Active"] = true;
            }
            else if (Convert.ToBoolean(Settings.Default["Timer2Active"]) == false)
            {
                Settings.Default["targetDateOnTimer2"] = targetDateOnTimer;
                Timer2.Visibility = Visibility.Visible;
                Timer2Title.Content = Settings.Default["Timer2Title"] = CreateNewTimerTitle.Text;
                Settings.Default["Timer2Active"] = true;
            }
            else if (Convert.ToBoolean(Settings.Default["Timer3Active"]) == false)
            {
                Settings.Default["targetDateOnTimer3"] = targetDateOnTimer;
                Timer3.Visibility = Visibility.Visible;
                Timer3Title.Content = Settings.Default["Timer3Title"] = CreateNewTimerTitle.Text;
                Settings.Default["Timer3Active"] = true;
            }
            else if (Convert.ToBoolean(Settings.Default["Timer4Active"]) == false)
            {
                Settings.Default["targetDateOnTimer4"] = targetDateOnTimer;
                Timer4.Visibility = Visibility.Visible;
                Timer4Title.Content = Settings.Default["Timer4Title"] = CreateNewTimerTitle.Text;
                Settings.Default["Timer4Active"] = true;
            }
            else if (Convert.ToBoolean(Settings.Default["Timer5Active"]) == false)
            {
                Settings.Default["targetDateOnTimer5"] = targetDateOnTimer;
                Timer5.Visibility = Visibility.Visible;
                Timer5Title.Content = Settings.Default["Timer5Title"] = CreateNewTimerTitle.Text;
                Settings.Default["Timer5Active"] = true;
            }
            else if (Convert.ToBoolean(Settings.Default["Timer6Active"]) == false)
            {
                Settings.Default["targetDateOnTimer6"] = targetDateOnTimer;
                Timer6.Visibility = Visibility.Visible;
                Timer6Title.Content = Settings.Default["Timer6Title"] = CreateNewTimerTitle.Text;
                Settings.Default["Timer6Active"] = true;
            }

            ResetCreateTimerSettings();
        }   
        


        private void HideCreateNewTimer_Button(object sender, RoutedEventArgs e)
        {
            CreateNewTimer_Grid.Visibility = Visibility.Collapsed;
            ResetCreateTimerSettings();
        }

        private void AddNewTimer_Button(object sender, RoutedEventArgs e)
        {
            CreateNewTimer_Grid.Visibility = Visibility.Visible;
        }

        private void EnableCountdown_Button(object sender, RoutedEventArgs e)
        {
            EnableCountdown.Background = Brushes.White;
            EnableCountTill.Background = Brushes.LightGray;

            Countdown_Stackpanel1.Visibility = Visibility.Visible;
            Countdown_Stackpanel2.Visibility = Visibility.Visible;

            CountTillDate_Stackpanel.Visibility = Visibility.Collapsed;
        }

        private void EnableCountTill_Button(object sender, RoutedEventArgs e)
        {
            EnableCountdown.Background = Brushes.LightGray;
            EnableCountTill.Background = Brushes.White;

            Countdown_Stackpanel1.Visibility = Visibility.Collapsed;
            Countdown_Stackpanel2.Visibility = Visibility.Collapsed;

            CountTillDate_Stackpanel.Visibility = Visibility.Visible;
        }

        private void ResetCreateTimerSettings()
        {
            EnableCountdown.Background = Brushes.White;
            EnableCountTill.Background = Brushes.LightGray;

            Countdown_Stackpanel1.Visibility = Visibility.Visible;
            Countdown_Stackpanel2.Visibility = Visibility.Visible;

            CountTillDate_Stackpanel.Visibility = Visibility.Collapsed;

            CreateNewTimerTitle.Text = "";
            HoursBox.SelectedIndex = 0;
            MinutesBox.SelectedIndex = 0;
            SecondsBox.SelectedIndex = 0;
            CountTillDate.Text = "";
        }

        private void HideGrids()
        {
            HomeGrid.Visibility = Visibility.Hidden;
            TimerGrid.Visibility = Visibility.Hidden;
            RemindersGrid.Visibility = Visibility.Hidden;
            WeatherGrid.Visibility = Visibility.Hidden;
            ConfigureGrid.Visibility = Visibility.Hidden;
        }

        

        private void DisplayForecast(string xml)
        {
            // Load the response into an XML document.
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.LoadXml(xml);

            string temperature = xml_doc.SelectSingleNode("//time/temperature").Attributes["value"].Value;
            temperature = temperature.Split('.')[0].Trim();
            // Get the city, country, latitude, and longitude.
            XmlNode loc_node = xml_doc.SelectSingleNode("weatherdata/location");
            txtSymbol.Content = xml_doc.SelectSingleNode("//time/symbol").Attributes["name"].Value;
            txtCity.Content = loc_node.SelectSingleNode("name").InnerText + ", " + loc_node.SelectSingleNode("country").InnerText;
            txtDegrees.Content = temperature;
            if (Convert.ToBoolean(Settings.Default["celsiusSelected"]))
            {
                txtDegrees.Content += "°C";
            }
            else
            {
                txtDegrees.Content += "°F";
            }


            for(int i = 0; i < 8; i++)
            {
                XmlNode time_node = xml_doc.SelectNodes("//time")[i];

                // Get the time in UTC.
                DateTime time = 
                    DateTime.Parse(time_node.Attributes["from"].Value,
                        null, DateTimeStyles.AssumeUniversal);

                // Get the temperature.
                XmlNode temp_node = time_node.SelectSingleNode("temperature");
                string temp = temp_node.Attributes["value"].Value;

                XmlNode symbol_node = time_node.SelectSingleNode("symbol");
                string symbol = symbol_node.Attributes["var"].Value;

                txtTimeTemps[i].Text = time.ToShortTimeString() + "\n";
                txtTimeTemps[i].Text += temp.Split('.')[0].Trim();
                if (Convert.ToBoolean(Settings.Default["celsiusSelected"]))
                    txtTimeTemps[i].Text += "°C";
                else
                    txtTimeTemps[i].Text += "°F";


                switch (symbol)
                {
                    case "01d":
                        txtTimeSymbols[i].Source = new BitmapImage(new Uri("Resources/wi-day-sunny.png", UriKind.Relative));
                        break;
                    case "01n":
                        txtTimeSymbols[i].Source = new BitmapImage(new Uri("Resources/wi-night-clear.png", UriKind.Relative));
                        break;
                    case "02d":
                        txtTimeSymbols[i].Source = new BitmapImage(new Uri("Resources/wi-day-cloudy.png", UriKind.Relative));
                        break;
                    case "02n":
                        txtTimeSymbols[i].Source = new BitmapImage(new Uri("Resources/wi-night-cloudy.png", UriKind.Relative));
                        break;
                    case "03d":

                    case "03n":

                    case "04d":

                    case "04n":
                        txtTimeSymbols[i].Source = new BitmapImage(new Uri("Resources/wi-cloudy.png", UriKind.Relative));
                        break;
                    case "09d":

                    case "10d":
                        txtTimeSymbols[i].Source = new BitmapImage(new Uri("Resources/wi-day-rain.png", UriKind.Relative));
                        break;

                    case "09n":

                        break;
                    case "10n":
                        txtTimeSymbols[i].Source = new BitmapImage(new Uri("Resources/wi-night-rain.png", UriKind.Relative));
                        break;
                    case "11d":
                        txtTimeSymbols[i].Source = new BitmapImage(new Uri("Resources/wi-day-lightning.png", UriKind.Relative));
                        break;
                    case "11n":
                        txtTimeSymbols[i].Source = new BitmapImage(new Uri("Resources/wi-night-lightning.png", UriKind.Relative));
                        break;
                    case "13d":
                        txtTimeSymbols[i].Source = new BitmapImage(new Uri("Resources/wi-day-snow.png", UriKind.Relative));
                        break;
                    case "13n":
                        txtTimeSymbols[i].Source = new BitmapImage(new Uri("Resources/wi-night-snow.png", UriKind.Relative));
                        break;
                    case "50d":

                    case "50n":
                        txtTimeSymbols[i].Source = new BitmapImage(new Uri("Resources/wi-fog.png", UriKind.Relative));
                        break;

                    default:
                        txtTimeSymbols[i].Source = new BitmapImage(new Uri("Resources/cog.png", UriKind.Relative));
                        break;
                }
            }          
        }

        private void App1Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount >= 2)
            {
                var noodes = new Noodes();
                noodes.Show();
            } 
        }

        private void App2Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                var colorpicker = new Colorpicker();
                colorpicker.Show();
            }
        }

        private void App3Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                var alarm = new Alarm();
                alarm.Show();
            }
        }

        private void App4Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                var timer = new Timer();
                timer.Show();
            }
        }

        private void Reminder1Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.Default["Reminder1Title"] = Reminder1Title.Text.ToString();
            Settings.Default.Save();
        }

        private void Reminder1Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.Default["Reminder1Text"] = Reminder1Text.Text.ToString();
            Settings.Default.Save();
        }

        private void Reminder2Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.Default["Reminder2Title"] = Reminder2Title.Text.ToString();
            Settings.Default.Save();
        }

        private void Reminder2Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.Default["Reminder2Text"] = Reminder2Text.Text.ToString();
            Settings.Default.Save();
        }

        private void Reminder3Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.Default["Reminder3Title"] = Reminder3Title.Text.ToString();
            Settings.Default.Save();
        }

        private void Reminder3Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.Default["Reminder3Text"] = Reminder3Text.Text.ToString();
            Settings.Default.Save();
        }

        private void Reminder4Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.Default["Reminder4Title"] = Reminder4Title.Text.ToString();
            Settings.Default.Save();
        }

        private void Reminder4Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.Default["Reminder4Text"] = Reminder4Text.Text.ToString();
            Settings.Default.Save();
        }

        private void Reminder5Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.Default["Reminder5Title"] = Reminder5Title.Text.ToString();
            Settings.Default.Save();
        }

        private void Reminder5Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.Default["Reminder5Text"] = Reminder5Text.Text.ToString();
            Settings.Default.Save();
        }

        private void Reminder6Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.Default["Reminder6Title"] = Reminder6Title.Text.ToString();
            Settings.Default.Save();
        }

        private void Reminder6Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Settings.Default["Reminder6Text"] = Reminder6Text.Text.ToString();
            Settings.Default.Save();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
