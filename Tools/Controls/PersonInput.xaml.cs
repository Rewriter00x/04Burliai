using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _01Burliai.Tools.Controls
{
    /// <summary>
    /// Interaction logic for PersonInput.xaml
    /// </summary>
    public partial class PersonInput : UserControl
    {

        public string Name
        {
            get { return TbName.Value; }
        }

        public string Surname
        {
            get { return TbSurname.Value; }
        }

        public string Email
        {
            get { return TbEmail.Value; }
        }

        public DateTime? Birthday
        {
            get { return (DateTime?)GetValue(BirthdayProperty); }
        }

        public ICommand ProceedCommand
        {
            get { return (ICommand)GetValue(ProceedCommandProperty); }
            set { SetValue(ProceedCommandProperty, value); }
        }

        public static readonly DependencyProperty BirthdayProperty = DependencyProperty.Register(
           "Birthday",
           typeof(DateTime?),
           typeof(PersonInput),
           new PropertyMetadata(null)
           );

        public static readonly DependencyProperty ProceedCommandProperty = DependencyProperty.Register(
            "ProceedCommand",
            typeof(ICommand),
            typeof(PersonInput),
            new PropertyMetadata(null)
        );

        public PersonInput()
        {
            InitializeComponent();
            DpBirthDate.DisplayDateEnd = DateTime.Today;
            DpBirthDate.DisplayDateStart = new DateTime(DateTime.Today.Year - 135, DateTime.Today.Month, DateTime.Today.Day);
        }
    }
}
