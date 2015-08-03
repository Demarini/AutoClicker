using AutoClicker1.ViewModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoClicker1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Storyboard expandAnim = (Storyboard)FindResource("MoveAnimation");
            expandAnim.Begin(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Storyboard expandAnim = (Storyboard)FindResource("MoveBackAnimation");
            expandAnim.Begin(this);
        }
    }
}
