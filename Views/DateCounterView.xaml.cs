using System.Windows.Controls;
using _01Burliai.ViewModels;

namespace _01Burliai.Views
{
    /// <summary>
    /// Interaction logic for DateCounterView.xaml
    /// </summary>
    public partial class DateCounterView : UserControl
    {
        public DateCounterView()
        {
            InitializeComponent();
            DataContext = new DateCounterViewModel();
        }
    }
}
