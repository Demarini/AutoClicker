using AutoClicker1.Model;
using AutoClicker1.Service;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoClicker1.ViewModel
{
    public class MousePositionViewModel : INotifyPropertyChanged
    {
        MousePositionService mousePositionService;
        MousePositionModel mousePositionModel;
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

        public MousePositionViewModel()
        {
            mousePositionModel = new MousePositionModel(this);
            mousePositionService = new MousePositionService(this, mousePositionModel);
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
                mousePositionModel.SpanValue = spanValue;
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
        public string BindText
        {
            get
            {
                return bindText;
            }
            set
            {
                bindText = value;
                mousePositionModel.BindText = bindText;
                OnPropertyChanged("BindText");
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
        public string SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                mousePositionModel.SelectedItem = selectedItem;
            }
        }
        public ICommand EditBind
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (mousePositionService.CheckEditValues())
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
            mousePositionService.CheckKeyPress();
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
