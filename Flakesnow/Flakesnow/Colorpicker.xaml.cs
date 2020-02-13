using System.Windows;
using System.Windows.Controls;

namespace Flakesnow
{
    /// <summary>
    /// Interaction logic for Colorpicker.xaml
    /// </summary>
    public partial class Colorpicker : Window
    {
        public Colorpicker()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void Copyhex_Click(object sender, RoutedEventArgs e)
        {
            string hex = ColorPickCanvas.R.ToString("X2") + ColorPickCanvas.G.ToString("X2") + ColorPickCanvas.B.ToString("X2");
            Clipboard.SetText("#" + hex);
        }

        private void CopyRGB_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText($"{ColorPickCanvas.R}, {ColorPickCanvas.G}, {ColorPickCanvas.B}");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var screenPickwindow = new Screenpickwindow();
            screenPickwindow.Owner = this;
            screenPickwindow.Show();
        }
    }
}
