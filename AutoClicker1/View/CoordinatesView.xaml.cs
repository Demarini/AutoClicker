﻿using AutoClicker1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoClicker1.View
{
    /// <summary>
    /// Interaction logic for CoordinatesView.xaml
    /// </summary>
    public partial class CoordinatesView : UserControl
    {
        public CoordinatesView()
        {
            this.DataContext = new CoordinatesViewModel();
            InitializeComponent();
            
        }
    }
}
