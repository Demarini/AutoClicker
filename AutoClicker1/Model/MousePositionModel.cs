using AutoClicker1.Service;
using AutoClicker1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker1.Model
{
    
    class MousePositionModel
    {
        MousePositionViewModel mousePositionViewModel;
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

        public MousePositionModel(MousePositionViewModel mousePositionViewModel)
        {
            this.mousePositionViewModel = mousePositionViewModel;
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
        public List<string> DropList
        {
            get
            {
                return dropList;
            }
            set
            {
                dropList = value;
                mousePositionViewModel.DropList = dropList;
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
                mousePositionViewModel.EditText = editText;
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
                mousePositionViewModel.IsEnabled = isEnabled;
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
    }
}
