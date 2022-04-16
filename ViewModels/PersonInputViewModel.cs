using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using _01Burliai.Annotations;
using _01Burliai.Models;
using _01Burliai.Tools;

namespace _01Burliai.ViewModels
{
    class PersonInputViewModel : INotifyPropertyChanged
    {
        

        #region Fields
        private Person _person = new Person("", "", "", null);

        #region Commands
        private RelayCommand<object> _proceedCommand;
        #endregion
        #endregion

        #region Properties
        public string Name
        {
            get { return _person.Name; }
            set { _person.Name = value; }
        }

        public string Surname
        {
            get { return _person.Surname; }
            set { _person.Surname = value; }
        }

        public string Email
        {
            get { return _person.Email; }
            set { _person.Email = value; }
        }

        public DateTime? Birthday
        {
            get { return _person.Birthday; }
            set { _person.Birthday = value; }
        }

        public string BirthdayString
        {
            get { return Birthday?.ToString("dd.MM.yyyy"); }
        }

        public WestZodiac SunSign
        {
            get { return _person.SunSign; }
        }

        public ChineseZodiac ChineseSign
        {
            get { return _person.ChineseSign; }
        }

        public string IsAdult
        {
            get { return _person.isAdult ? "Is adult" : "Is not adult"; }
        }

        public string IsBirthday
        {
            get { return _person.isBirthday ? "Is birthday" : "Is not birthday"; }
        }

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), _ => CanExecute());
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private void UpdateSunSign()
        {
            _person.UpdateSunSign();
            OnPropertyChanged(nameof(SunSign));
        }

        private void UpdateChineseSign()
        {
            _person.UpdateChineseSign();
            OnPropertyChanged(nameof(ChineseSign));
        }

        private async void Proceed()
        {
            await Task.Run(() => UpdateSunSign());
            await Task.Run(() => UpdateChineseSign());
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Surname));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(BirthdayString));
            OnPropertyChanged(nameof(IsAdult));
            OnPropertyChanged(nameof(IsBirthday));
        }

        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(_person.Name) && !string.IsNullOrWhiteSpace(_person.Surname) && !string.IsNullOrWhiteSpace(_person.Email) && _person.Birthday != null;
        }
    }
}
