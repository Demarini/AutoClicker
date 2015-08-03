using AutoClicker1.Model;
using AutoClicker1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AutoClicker1.Service
{
    public class ColorService
    {
        
        private ColorViewModel colorViewModel;
        ColorModel colorModel;
        public ColorService(ColorViewModel colorViewModel, ColorModel colorModel)
        {
            this.colorViewModel = colorViewModel;
            this.colorModel = colorModel;
        }
        
        public void SelectColor()
        {
            MouseHook.Start();
            MouseHook.MouseAction += new EventHandler(Event);
        }
        private void Event(object sender, EventArgs e)
        {
            bool canAdd = true;
            MouseHook.stop();
            System.Drawing.Color color = GetPixelColor(MouseHook.X, MouseHook.Y); // This is your color to convert from
            System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            ListBoxBinder listBoxBinder = new ListBoxBinder();
            listBoxBinder.Foreground = new SolidColorBrush(newColor);
            listBoxBinder.Background = Brushes.White;
            listBoxBinder.Content = newColor.ToString();
            foreach (ListBoxBinder lb in colorModel.ListBind)
            {
                if (lb.Content == listBoxBinder.Content)
                {
                    canAdd = false;
                }
            }
            if (canAdd)
            {
                colorModel.ListBind.Add(listBoxBinder);
            }
            colorViewModel.ListBind = null;
            colorModel.ListBind = colorModel.ListBind;
        }
        static public System.Drawing.Color GetPixelColor(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            System.Drawing.Color color = System.Drawing.Color.FromArgb((int)(pixel & 0x000000FF),
                         (int)(pixel & 0x0000FF00) >> 8,
                         (int)(pixel & 0x00FF0000) >> 16);
            return color;
        }

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(IntPtr dc, int x, int y);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr window, IntPtr dc);
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);
    }
}
