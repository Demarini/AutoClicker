using AutoClicker1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker1.Model
{
    public class CoordinatesModel
    {
        CoordinatesViewModel coordinatesViewModel;
        private string bindText;
        private string editText = "Edit Bind";
        private bool isEnabled = false;
        private bool isEnabledX = false;
        private bool isEnabledY = false;
        private string selectedItem;
        private string x;
        private string y;
        private List<string> dropList = new List<string>();
        private string spanValue;
        public CoordinatesModel(CoordinatesViewModel coordinatesViewModel)
        {
            this.coordinatesViewModel = coordinatesViewModel;
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
                coordinatesViewModel.DropList = dropList;
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
        public string EditText
        {
            get
            {
                return editText;
            }
            set
            {
                editText = value;
                coordinatesViewModel.EditText = editText;
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
                coordinatesViewModel.IsEnabled = isEnabled;
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
                coordinatesViewModel.IsEnabledX = isEnabledX;
            }
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
                coordinatesViewModel.IsEnabledY = isEnabledY;
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
                //colorViewModel.BindText = bindText;
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
                //colorViewModel.BindText = bindText;
            }
        }
    }
}
