using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Runtime.InteropServices;

namespace Flakesnow
{
    /// <summary>
    /// Interaction logic for Screenpickwindow.xaml
    /// </summary>
    public partial class Screenpickwindow : Window
    {
        public Screenpickwindow()
        {
            InitializeComponent();
        }

        [DllImport("gdi32.dll")]
        static public extern uint GetPixel(IntPtr hDC, int XPos, int YPos);
        [DllImport("gdi32.dll")]
        static public extern IntPtr CreateDC(string driverName, string deviceName, string output, IntPtr lpinitData);
        [DllImport("gdi32.dll")]
        static public extern bool DeleteDC(IntPtr DC);
        static public byte GetRValue(uint color)
        {
            return (byte)color;
        }
        static public byte GetGValue(uint color)
        {
            return ((byte)(((short)(color)) >> 8));
        }
        static public byte GetBValue(uint color)
        {
            return ((byte)((color) >> 16));
        }
        static public byte GetAValue(uint color)
        {
            return ((byte)((color) >> 24));
        }
        public Color GetColor(Point screenPoint)
        {
            IntPtr displayDC = CreateDC("DISPLAY", null, null, IntPtr.Zero);
            uint colorref = GetPixel(displayDC, Convert.ToUInt16(screenPoint.X), Convert.ToUInt16(screenPoint.Y));
            DeleteDC(displayDC);
            byte Red = GetRValue(colorref);
            byte Green = GetGValue(colorref);
            byte Blue = GetBValue(colorref);
            return Color.FromRgb(Red, Green, Blue);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point pointToScreen = Mouse.GetPosition(this);
            Point screenPosition = PointToScreen(pointToScreen);
            Color cl = GetColor(screenPosition);
            (this.Owner as Colorpicker).ColorPickCanvas.SelectedColor = cl;

            this.Close();
        }
    }
}
