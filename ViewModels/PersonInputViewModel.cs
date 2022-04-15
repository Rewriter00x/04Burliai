using System;
using _01Burliai.Tools;
using _01Burliai.Models;

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
            
        }

        private bool CanExecute()
        {
            return _person.Birthday != null;
        }
    }
}
