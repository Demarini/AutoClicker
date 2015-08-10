using AutoClicker1.Model;
using AutoClicker1.Service;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoClicker1.ViewModel
{
    public class CoordinatesViewModel : INotifyPropertyChanged
    {
        CoordinatesService coordinatesService;
        CoordinatesModel coordinatesModel;
        private string bindText;
        private string selectedItem;
        private string editText = "Edit Bind";
        private bool isEnabled = false;
        private bool isEnabledX = false;
        private bool isEnabledY = false;
        private string x;
        private string y;
        private string spanValue;
        private List<string> dropList = new List<string>();
        public CoordinatesViewModel()
        {
            coordinatesModel = new CoordinatesModel(this);
            coordinatesService = new CoordinatesService(this, coordinatesModel);
        }
        public string SpanValue
        {
            get
            {
                return spanValue;
            }
            set
            {
                spanValue = value;
                coordinatesModel.SpanValue = spanValue;
            }
        }
        public List<string> DropList
        {
            get
            {
                return dropList;
            }
            set
            {
                dropList = value;
            }
        }
        public string SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                coordinatesModel.SelectedItem = selectedItem;
            }
        }
        public string EditText
        {
            get
            {
                return editText;
            }
            set
            {
                editText = value;
                OnPropertyChanged("EditText");
            }
        }
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }
        public bool IsEnabledX
        {
            get
            {
                return isEnabledX;
            }
            set
            {
                isEnabledX = value;
                OnPropertyChanged("IsEnabledX");
            }
        }
        public ICommand EditBind
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (coordinatesService.CheckEditValues())
                    {
                        KeyboardHook.UnsetHook();
                    }
                    else
                    {
                        KeyboardHook.SetHook();
                        KeyboardHook.KeyAction += new EventHandler(Event2);
                    }
                });
            }
        }
        private void Event2(object sender, EventArgs e)
        {
            coordinatesService.CheckKeyPress();
        }
        public bool IsEnabledY
        {
            get
            {
                return isEnabledY;
            }
            set
            {
                isEnabledY = value;
                OnPropertyChanged("IsEnabledY");
            }
        }
        public string BindText
        {
            get
            {
                return bindText;
            }
            set
            {
                bindText = value;
                coordinatesModel.BindText = bindText;
                OnPropertyChanged("BindText");
            }
        }
        public string X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                coordinatesModel.X = x;
                OnPropertyChanged("X");
            }
        }
        public string Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                coordinatesModel.Y = y;
                OnPropertyChanged("Y");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}