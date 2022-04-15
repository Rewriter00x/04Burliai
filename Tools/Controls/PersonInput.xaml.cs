using System;
using System.Windows.Controls;

namespace _01Burliai.Tools.Controls
{
    /// <summary>
    /// Interaction logic for PersonInput.xaml
    /// </summary>
    public partial class PersonInput : UserControl
    {
        public PersonInput()
        {
            InitializeComponent();
            DpBirthDate.DisplayDateEnd = DateTime.Today;
            DpBirthDate.DisplayDateStart = new DateTime(DateTime.Today.Year - 135, DateTime.Today.Month, DateTime.Today.Day);
        }
    }
}
