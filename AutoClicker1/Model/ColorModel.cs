using AutoClicker1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AutoClicker1.Model
{
    public class ColorModel
    {
        ColorViewModel colorViewModel;
        private List<ListBoxBinder> listBind = new List<ListBoxBinder>();
        public ColorModel(ColorViewModel colorViewModel)
        {
            this.colorViewModel = colorViewModel;
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
                colorViewModel.ListBind = listBind;
            }
        }
    }
}
