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

namespace _01Burliai.Tools.Controls
{
    /// <summary>
    /// Interaction logic for DateSelector.xaml
    /// </summary>
    public partial class DateSelector : UserControl
    {

        public string Caption
        {
            get { return TbCaption.Text;}
            set { TbCaption.Text = value; }
        }

        public DateTime Date
        {
            get { return (DateTime)DatePicker.SelectedDate; }
            set { DatePicker.SelectedDate = value; }
        }

        public DateSelector()
        {
            InitializeComponent();
        }
    }
}
