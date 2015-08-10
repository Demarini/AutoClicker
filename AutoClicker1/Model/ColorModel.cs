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
        public string bindText;
        public string editText = "Edit Bind";
        public bool isEnabled = false;
        private string spanValue;
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
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                colorViewModel.IsEnabled = isEnabled;
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
                colorViewModel.EditText = editText;
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
                //colorViewModel.BindText = bindText;
            }
        }
    }
}
