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
    class MousePositionService
    {
        Thread myThread;
        bool killThread = false;
        bool threadStarted = false;
        public MousePositionViewModel mousePositionViewModel;
        public MousePositionModel mousePositionModel;

        public MousePositionService(MousePositionViewModel mousePositionViewModel, MousePositionModel mousePositionModel)
        {
            this.mousePositionModel = mousePositionModel;
            this.mousePositionViewModel = mousePositionViewModel;
        }
        public bool CheckEditValues()
        {
            if (mousePositionModel.EditText == "Lock Bind")
            {
                mousePositionModel.EditText = "Edit Text";
                mousePositionModel.IsEnabled = false;
                return false;
            }
            else
            {
                mousePositionModel.EditText = "Lock Bind";
                mousePositionModel.IsEnabled = true;
                return true;
            }
        }
        public void CheckKeyPress()
        {
            if ((mousePositionModel.BindText.ToUpper() == KeyboardHook.KeyPressed.ToUpper()) && !threadStarted)
            {
                mousePositionModel.EditText = "111Text";
                StartClicking();
            }
            else if (KeyboardHook.KeyPressed.ToUpper() == "KEYDOWN")
            {
            }
            else
            {
                mousePositionModel.EditText = "asdft";
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
            milliSpan = GetMillisecondSpan(mousePositionModel.SelectedItem.Split(' ')[1].ToString(), mousePositionModel.SpanValue);
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
        public void CheckClickRequirement(double milliSecondSpan, Stopwatch sw)
        {
            Thread.Sleep((int)milliSecondSpan);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            sw.Stop();
            sw.Reset();
            sw.Start();
        }
    }
}
