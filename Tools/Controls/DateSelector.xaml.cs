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

        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty SelectedDateProperty = DependencyProperty.Register(
            "SelectedDate",
            typeof(DateTime?),
            typeof(DateSelector),
            new PropertyMetadata(null)
            );

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command",
            typeof(ICommand),
            typeof(DateSelector),
            new PropertyMetadata(null)
        );

        public DateSelector()
        {
            InitializeComponent();
            DatePicker.DisplayDateEnd = DateTime.Today;
        }
    }
}
