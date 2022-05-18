using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using _01Burliai.Annotations;
using _01Burliai.Models;
using _01Burliai.Models.Exceptions;
using _01Burliai.Repositories;
using _01Burliai.Tools;

namespace _01Burliai.ViewModels
{
    class PersonInputViewModel : INotifyPropertyChanged
    {
        
        #region Fields
        private Person _person = new Person("", "", "", null);
        private ObservableCollection<Person> _persons;
        private Person _selectedPerson = null;
        private FileRepository _repository = new FileRepository();

        private int _enabled = 0;
        private bool _filtered = false;

        private Person _prevPerson = null;

        #region Commands
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _deleteCommand;
        private RelayCommand<object> _filterCommand;
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
            get { return _person.BirthdayString; }
            set { _person.BirthdayString = value; }
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
            get { return _person.IsAdult ? "Is adult" : "Is not adult"; }
        }

        public string IsBirthday
        {
            get { return _person.IsBirthday ? "Is birthday" : "Is not birthday"; }
        }

        public ObservableCollection<Person> Persons
        {
            get { return _filtered ? new ObservableCollection<Person>(_persons.Where(p=>p.IsAdult).OrderBy(p=>p)) : _persons; }
            private set 
            { 
                _persons = value;
                OnPropertyChanged(nameof(Persons));
            }
        }

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), _ => CanExecuteProceed());
            }
        }

        public RelayCommand<object> DeleteCommand
        {
            get
            {
                return _deleteCommand ??= new RelayCommand<object>(_ => Delete(), _ => CanExecuteDelete());
            }
        }

        public RelayCommand<object> FilterCommand
        {
            get
            {
                return _filterCommand ??= new RelayCommand<object>(_ => Filter(), _ => CanExecuteFilter());
            }
        }

        public Person SelectedPerson
        {
            get
            {
                return _selectedPerson; 
            }
            set {
                if (_selectedPerson != null && value != null)
                {
                    _repository.Remove(_prevPerson);
                    UpdatePerson(_selectedPerson);
                }
                _selectedPerson = value;
                if (_selectedPerson != null)
                    _prevPerson = (Person)_selectedPerson.Clone();
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _enabled == 0;
            }
        }
        #endregion

        public PersonInputViewModel()
        {
            _persons = _repository.Persons;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private void CheckEmail()
        {
            _person.CheckEmail(_person.Email);
        }

        private void CheckDate()
        {
            _person.CheckDate(_person.Birthday);
        }

        private bool CheckData()
        {
            bool res = true;
            try
            {
                CheckEmail();
            } catch (WrongEmailException e)
            {
                MessageBox.Show(e.Message);
                res = false;
            }
            try
            {
                CheckDate();
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
                res = false;
            } 
            return res;
        }

        private async void UpdatePerson(Person p)
        {
            await _repository.AddOrUpdateAsync(p);
        }

        private void Proceed()
        {
            if (!CheckData())
                return;

            Person p = (Person)_person.Clone();
            _persons.Add(p);
            UpdatePerson(p);
        }

        private void Delete()
        {
            _repository.Remove(_selectedPerson);
            _persons.Remove(_selectedPerson);
        }

        private void Filter()
        {
            _filtered = !_filtered;
            OnPropertyChanged(nameof(Persons));
        }

        private bool CanExecuteProceed()
        {
            return !string.IsNullOrWhiteSpace(_person.Name) && !string.IsNullOrWhiteSpace(_person.Surname) && !string.IsNullOrWhiteSpace(_person.Email) && _person.Birthday != null;
        }

        private bool CanExecuteDelete()
        {
            return _selectedPerson != null;
        }

        private bool CanExecuteFilter()
        {
            return Persons.Count > 0;
        }
    }
}
