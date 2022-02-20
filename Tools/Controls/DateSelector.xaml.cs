using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        }
    }
}
