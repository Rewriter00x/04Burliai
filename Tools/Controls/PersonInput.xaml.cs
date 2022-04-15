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

        public string PersonName
        {
            get { return (string)GetValue(PersonNameProperty); }
            set { SetValue(PersonNameProperty, value); }
        }

        public string PersonSurname
        {
            get { return (string)GetValue(PersonSurnameProperty); }
            set { SetValue(PersonSurnameProperty, value); }
        }

        public string PersonEmail
        {
            get { return (string)GetValue(PersonEmailProperty); }
            set { SetValue(PersonEmailProperty, value); }
        }

        public DateTime? Birthday
        {
            get { return (DateTime?)GetValue(BirthdayProperty); }
            set { SetValue(BirthdayProperty, value); }
        }

        public ICommand ProceedCommand
        {
            get { return (ICommand)GetValue(ProceedCommandProperty); }
            set { SetValue(ProceedCommandProperty, value); }
        }

        public static readonly DependencyProperty PersonNameProperty = DependencyProperty.Register(
            "PersonName",
            typeof(string),
            typeof(PersonInput),
            new PropertyMetadata(null)
            );

        public static readonly DependencyProperty PersonSurnameProperty = DependencyProperty.Register(
            "PersonSurname",
            typeof(string),
            typeof(PersonInput),
            new PropertyMetadata(null)
            );

        public static readonly DependencyProperty PersonEmailProperty = DependencyProperty.Register(
            "PersonEmail",
            typeof(string),
            typeof(PersonInput),
            new PropertyMetadata(null)
            );

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
