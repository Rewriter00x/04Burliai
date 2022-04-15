using System.Windows.Controls;
using _01Burliai.ViewModels;

namespace _01Burliai.Views
{
    /// <summary>
    /// Interaction logic for PersonInputView.xaml
    /// </summary>
    public partial class PersonInputView : UserControl
    {
        public PersonInputView()
        {
            InitializeComponent();
            DataContext = new PersonInputViewModel();
        }
    }
}
