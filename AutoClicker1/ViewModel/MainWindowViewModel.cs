using AutoClicker1.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace AutoClicker1.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private FrameworkElement clickedView;
        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindowViewModel()
        {

        }
        public ICommand MousePositionClick
        {
            get
            {
                return new RelayCommand(() =>
                {
                    ClickedView = new MousePositionView();
                    ClickedView.DataContext = new MousePositionViewModel();
                });
            }
        }
        public ICommand CoordinatesClick
        {
            get
            {
                return new RelayCommand(() =>
                {
                    ClickedView = new CoordinatesView();
                    ClickedView.DataContext = new CoordinatesViewModel();
                });
            }
        }
        public ICommand ColorClick
        {
            get
            {
                return new RelayCommand(() =>
                {
                    ClickedView = new ColorView();
                    ClickedView.DataContext = new ColorViewModel();
                });
            }
        }
        #region NotifyPropertyChanged
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public FrameworkElement ClickedView
        {
            get
            {
                return clickedView;
            }
            set
            {
                clickedView = value;
                OnPropertyChanged("ClickedView");
            }
        }
        
    }
}
