using AutoClicker1.Model;
using AutoClicker1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace AutoClicker1.Service
{
    public class ColorService
    {
        Thread myThread;
        bool killThread = false;
        bool threadStarted = false;
        bool _shouldStop;
        private ColorViewModel colorViewModel;
        ColorModel colorModel;
        public ColorService(ColorViewModel colorViewModel, ColorModel colorModel)
        {
            
            this.colorViewModel = colorViewModel;
            this.colorModel = colorModel;
        }
        
        public void SelectColor()
        {
            SetListBoxColor();
        }
        public void SetListBoxColor()
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
        public void CheckKeyPress()
        {
            if ((colorModel.BindText.ToUpper() == KeyboardHook.KeyPressed.ToUpper()) && !threadStarted)
            {
                killThread = false;
                colorModel.EditText = "YOLO";
                StartClicking();
                
            }
            else if (KeyboardHook.KeyPressed.ToUpper() == "KEYDOWN")
            {
            }
            else
            {
                killThread = true;
                threadStarted = false;
                myThread.Abort();
                colorModel.EditText = "NOYOLO";
            }
        }
        public bool CheckEditValues()
        {
            if (colorModel.EditText == "Lock Bind")
            {
                colorModel.EditText = "Edit Text";
                colorModel.IsEnabled = false;
                return false;
            }
            else
            {
                colorModel.EditText = "Lock Bind";
                colorModel.IsEnabled = true;
                return true;
            }
        }
        public void StartClicking()
        {
            threadStarted = true;
            List<ListBoxBinder> ls2 = new List<ListBoxBinder>();
            foreach (ListBoxBinder ls in colorModel.ListBind)
            {
                ListBoxBinder ls3 = new ListBoxBinder();
                ls3.Background = ls.Background;
                ls3.Foreground = ls.Foreground;
                ls3.Content = ls.Content;
                ls3.ListBoxBinders = ls.ListBoxBinders;
                ls2.Add(ls3);
            }
            //Application.Current.Dispatcher.Invoke((Action)(() =>
            //{
            //    CheckClickRequirement(ls2);
            //}));
            //Application.Current.Dispatcher.Invoke(new Action(() => { CheckClickRequirement(ls2); }), DispatcherPriority.ContextIdle, null);
            
            myThread = new System.Threading.Thread(delegate()
            {

                while (!killThread)
                {
                    CheckClickRequirement(ls2);
                }
                killThread = false;
                threadStarted = false;
                //colorModel.EditText = "SWAG";
            });
            myThread.IsBackground = true;
            myThread.Start();
        }
        public void CheckClickRequirement(List<ListBoxBinder> ls2)
        {
                foreach (ListBoxBinder ls in ls2)
                {
                    System.Drawing.Point p = MouseHook.GetCursorPosition();
                    System.Drawing.Color c = GetPixelColor(p.X, p.Y);
                    System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);
                    if (ls.Content == newColor.ToString())
                    {
                        MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                        MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                    }
                }
        }


        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(IntPtr dc, int x, int y);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr window, IntPtr dc);
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);
    }
}
