using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
namespace AutoClicker1
{
    public class ListBoxBinder
    {
        private SolidColorBrush backGround;
        private SolidColorBrush foreGround;
        private string content;
        private List<ListBoxBinder> listBoxBinders = new List<ListBoxBinder>();
        public ListBoxBinder()
        {
            
        }
        public SolidColorBrush Background
        {
            get
            {
                return backGround;
            }
            set
            {
                backGround = value;
            }
        }
        public SolidColorBrush Foreground
        {
            get
            {
                return foreGround;
            }
            set
            {
                foreGround = value;
            }
        }
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }
        public List<ListBoxBinder> ListBoxBinders
        {
            get
            {
                return listBoxBinders;
            }
            set
            {
                listBoxBinders = value;
            }
        }
    }
}
