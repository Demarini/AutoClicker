using AutoClicker1.Model;
using AutoClicker1.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoClicker1.Service
{
    public class CoordinatesService
    {
        Thread myThread;
        bool killThread = false;
        bool threadStarted = false;
        public CoordinatesViewModel coordinatesViewModel;
        public CoordinatesModel coordinatesModel;
        public CoordinatesService(CoordinatesViewModel coordinatesViewModel, CoordinatesModel coordinatesModel)
        {

            this.coordinatesViewModel = coordinatesViewModel;
            this.coordinatesModel = coordinatesModel;
        }
        public void CheckKeyPress()
        {
            if ((coordinatesModel.BindText.ToUpper() == KeyboardHook.KeyPressed.ToUpper()) && !threadStarted)
            {
                coordinatesModel.EditText = "111Text";
                StartClicking();
            }
            else if (KeyboardHook.KeyPressed.ToUpper() == "KEYDOWN")
            {
            }
            else
            {
                coordinatesModel.EditText = "asdft";
                killThread = true;
            }
        }
        public double GetMillisecondSpan(string timeValue, string span)
        {
            switch (timeValue)
            {
                case "Millisecond":
                    return double.Parse(span);
                case "Second":
                    return (double.Parse(span) * 1000);
                case "Minute":
                    return (double.Parse(span) * 1000) / 60;
                case "Hour":
                    return (double.Parse(span) * 1000) / 60 / 60;
            }
            return 0;
        }
        public void StartClicking()
        {
            threadStarted = true;
            double milliSpan = 0;
            milliSpan = GetMillisecondSpan(coordinatesModel.SelectedItem.Split(' ')[1].ToString(), coordinatesModel.SpanValue);
            myThread = new System.Threading.Thread(delegate()
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (!killThread)
                {
                    CheckClickRequirement(milliSpan, sw);
                }
                killThread = false;
                threadStarted = false;
                //colorModel.EditText = "SWAG";
            });
            myThread.Start();
        }
        public bool CheckEditValues()
        {
            if (coordinatesModel.EditText == "Lock Bind")
            {
                coordinatesModel.EditText = "Edit Text";
                coordinatesModel.IsEnabled = false;
                return false;
            }
            else
            {
                coordinatesModel.EditText = "Lock Bind";
                coordinatesModel.IsEnabled = true;
                return true;
            }
        }
        public void CheckClickRequirement(double milliSecondSpan, Stopwatch sw)
        {
            if (sw.ElapsedMilliseconds > milliSecondSpan)
            {
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown, int.Parse(coordinatesModel.X), int.Parse(coordinatesModel.Y));
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp, int.Parse(coordinatesModel.X), int.Parse(coordinatesModel.Y));
                sw.Stop();
                sw.Reset();
                sw.Start();
            }
            
        }
    }
}