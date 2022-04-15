using System;
using _01Burliai.Tools;
using _01Burliai.Models;
using System.Windows;

namespace _01Burliai.ViewModels
{
    class PersonInputViewModel
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

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), _ => CanExecute());
            }
        }
        #endregion

        private void Proceed()
        {
            MessageBox.Show("Name: " + _person.Name + "\nSurname: " + _person.Surname + "\nEmail: " + _person.Email + "\nBirthday: " + _person.Birthday?.Day + "." + _person.Birthday?.Month + "." + _person.Birthday?.Year);
        }

        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(_person.Name) && !string.IsNullOrWhiteSpace(_person.Surname) && !string.IsNullOrWhiteSpace(_person.Email) && _person.Birthday != null;
        }
    }
}
