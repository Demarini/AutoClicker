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
using System.Windows.Media;

namespace AutoClicker1.ViewModel
{
    public class ColorViewModel : INotifyPropertyChanged
    {
        private List<ListBoxBinder> listBind = new List<ListBoxBinder>();
        ColorService colorService;
        ColorModel colorModel;
        public string bindText;
        public string editText = "Edit Bind";
        public bool isEnabled = false;
        public ColorViewModel()
        {
            colorModel = new ColorModel(this);
            colorService = new ColorService(this, colorModel);
        }
        public ICommand SelectClick
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MouseHook.Start();
                    MouseHook.MouseAction += new EventHandler(Event);
                });
            }
        }
        public ICommand EditBind
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (colorService.CheckEditValues())
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
        private void Event(object sender, EventArgs e)
        {
            colorService.SelectColor();
        }
        public ICommand KeyPressed
        {
            get
            {
                return new RelayCommand<KeyEventArgs>(e =>
                {
                    
                });
            }
        }
        public List<ListBoxBinder> ListBind
        {
            get
            {
                return listBind;
            }
            set
            {
                listBind = value;
                OnPropertyChanged("ListBind");
            }
        }
        private void Event2(object sender, EventArgs e)
        {
            colorService.CheckKeyPress();
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
                colorModel.BindText = bindText;
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