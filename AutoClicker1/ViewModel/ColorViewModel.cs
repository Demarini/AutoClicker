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
                    colorService.SelectColor();
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