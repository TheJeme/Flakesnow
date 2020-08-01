using System;
using System.Windows;
using System.Windows.Input;

namespace Flakesnow
{
    /// <summary>
    /// Interaction logic for Noodes.xaml
    /// </summary>
    public partial class Noodes : Window
    {
        public Noodes()
        {
            InitializeComponent();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e) //Closes the window
        {
            this.Close();
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e) //Minimizes the window
        {
            this.WindowState = WindowState.Minimized;
        }
        private void NewButton_Click(object sender, RoutedEventArgs e) //Opens new window
        {
            var win2 = new Noodes();
            win2.Show();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //For dragging the window
        {
            this.DragMove();
        }
        private void TxtEditor_PreviewMouseWheel(object sender, MouseWheelEventArgs e) //Changes the fontsize
        {
            if (e.Delta > 0 && Keyboard.Modifiers == ModifierKeys.Control)
                try
                {
                    txtBox.FontSize += 1;
                }
                catch (Exception)
                {
                    return;
                }
            else if (e.Delta < 0 && Keyboard.Modifiers == ModifierKeys.Control)
                try
                {
                    txtBox.FontSize -= 1;
                }
                catch (Exception)
                {
                    return;
                }
        }
    }
}
