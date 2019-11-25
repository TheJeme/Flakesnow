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
                txtGood.Content = "Good morning, Jeme";
            else if (hourNow >= 12 && hourNow < 18)
                txtGood.Content = "Good afternoon, Jeme";
            else if (hourNow >= 18 || hourNow < 5)
                txtGood.Content = "Good evening, Jeme";
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
        bool celsiusSelected = true;

        bool changedReminder1Text;
        bool changedReminder2Text;
        bool changedReminder3Text;
        bool changedReminder4Text;
        bool changedReminder5Text;
        bool changedReminder6Text;

        bool changedReminder1Title;
        bool changedReminder2Title;
        bool changedReminder3Title;
        bool changedReminder4Title;
        bool changedReminder5Title;
        bool changedReminder6Title;

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

            celsiusSelected = true;
            unitSystem = "metric";
        }

        private void FahrenheitButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CelsiusButton.Background = Brushes.LightGray;
            FahrenheitButton.Background = Brushes.White;

            celsiusSelected = false;
            unitSystem = "imperial";
        }
        
        private void border1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HideGrids();
            HomeGrid.Visibility = Visibility.Visible;

            DateTime timeNow = DateTime.Now;
            int hourNow = timeNow.Hour;

            if (hourNow >= 5 && hourNow < 12)
                txtGood.Content = "Good morning, Jeme";
            else if (hourNow >= 12 && hourNow < 18)
                txtGood.Content = "Good afternoon, Jeme";
            else if (hourNow >= 18 || hourNow < 5)
                txtGood.Content = "Good evening, Jeme";
            else
                txtGood.Content = hourNow;
        }

        private void border2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HideGrids();
            StatsGrid.Visibility = Visibility.Visible;
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


            // Compose the query URL.
            string url = ForecastUrl.Replace("@LOC@", txtLocation.Text);
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
            Settings.Default.Save();
            changedReminder1Title = false;
            changedReminder1Text = false;
        }

        private void DeleteReminder2_Button(object sender, MouseButtonEventArgs e)
        {
            Reminder2.Visibility = Visibility.Collapsed;
            Settings.Default["Reminder2Active"] = false;
            Settings.Default.Save();
            changedReminder2Title = false;
            changedReminder2Text = false;
        }

        private void DeleteReminder3_Button(object sender, MouseButtonEventArgs e)
        {
            Reminder3.Visibility = Visibility.Collapsed;
            Settings.Default["Reminder3Active"] = false;
            Settings.Default.Save();
            changedReminder3Title = false;
            changedReminder3Text = false;
        }

        private void DeleteReminder4_Button(object sender, MouseButtonEventArgs e)
        {
            Reminder4.Visibility = Visibility.Collapsed;
            Settings.Default["Reminder4Active"] = false;
            Settings.Default.Save();
            changedReminder4Title = false;
            changedReminder4Text = false;
        }

        private void DeleteReminder5_Button(object sender, MouseButtonEventArgs e)
        {
            Reminder5.Visibility = Visibility.Collapsed;
            Settings.Default["Reminder5Active"] = false;
            Settings.Default.Save();
            changedReminder5Title = false;
            changedReminder5Text = false;
        }

        private void DeleteReminder6_Button(object sender, MouseButtonEventArgs e)
        {
            Reminder6.Visibility = Visibility.Collapsed;
            Settings.Default["Reminder6Active"] = false;
            Settings.Default.Save();
            changedReminder6Title = false;
            changedReminder6Text = false;
        }

        private void Reminder1Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!changedReminder1Title)
            {
                Reminder1Title.Text = "";
                changedReminder1Title = true;
            }
        }

        private void Reminder1Text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!changedReminder1Text)
            {
                Reminder1Text.Text = "";
                changedReminder1Text = true;
            }
        }

        private void Reminder2Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!changedReminder2Title)
            {
                Reminder2Title.Text = "";
                changedReminder2Title = true;
            }
        }

        private void Reminder2Text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!changedReminder2Text)
            {
                Reminder2Text.Text = "";
                changedReminder2Text = true;
            }
        }

        private void Reminder3Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!changedReminder3Title)
            {
                Reminder3Title.Text = "";
                changedReminder3Title = true;
            }
        }

        private void Reminder3Text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!changedReminder3Text)
            {
                Reminder3Text.Text = "";
                changedReminder3Text = true;
            }
        }

        private void Reminder4Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!changedReminder4Title)
            {
                Reminder4Title.Text = "";
                changedReminder4Title = true;
            }
        }

        private void Reminder4Text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!changedReminder4Text)
            {
                Reminder4Text.Text = "";
                changedReminder4Text = true;
            }
        }

        private void Reminder5Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!changedReminder5Title)
            {
                Reminder5Title.Text = "";
                changedReminder5Title = true;
            }
        }

        private void Reminder5Text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!changedReminder5Text)
            {
                Reminder5Text.Text = "";
                changedReminder5Text = true;
            }
        }

        private void Reminder6Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!changedReminder6Title)
            {
                Reminder6Title.Text = "";
                changedReminder6Title = true;
            }
        }

        private void Reminder6Text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!changedReminder6Text)
            {
                Reminder6Text.Text = "";
                changedReminder6Text = true;
            }
        }


        private void HideGrids()
        {
            HomeGrid.Visibility = Visibility.Hidden;
            StatsGrid.Visibility = Visibility.Hidden;
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
            if(celsiusSelected)
                txtDegrees.Content += "°C";
            else
                txtDegrees.Content += "°F";


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
                if (celsiusSelected)
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
                Process.Start(@"D:\KOODAUS\C#\Work In Progress\Noodes\Noodes\bin\Release\Noodes.exe");
            }
        }

        private void App2Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                Process.Start(@"D:\KOODAUS\C#\Work In Progress\Noodes\Noodes\bin\Release\Noodes.exe");
            }
        }

        private void App3Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                Process.Start(@"D:\KOODAUS\C#\Work In Progress\Noodes\Noodes\bin\Release\Noodes.exe");
            }
        }

        private void App4Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                Process.Start(@"D:\KOODAUS\C#\Work In Progress\Noodes\Noodes\bin\Release\Noodes.exe");
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
