using _01Burliai.Annotations;
using _01Burliai.Models.Exceptions;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01Burliai.Models
{
    class Person : ICloneable, INotifyPropertyChanged
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _birthday;
        private ZodiacSigns _signs = new ZodiacSigns();
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Email
        {
            get { return _email; }
            set { 
                try
                {
                    CheckEmail(value);
                    _email = value;
                }
                catch
                {

                }
            }
        }

        public DateTime? Birthday
        {
            get { return _birthday; }
            set { 
                _birthday = value;
                _signs.Date = _birthday;
            }
        }

        public string BirthdayString
        {
            get { return Birthday?.ToString("dd.MM.yyyy"); }
            set
            {
                try
                {
                    DateTime temp = DateTime.ParseExact(value, "dd.MM.yyyy", null);
                    CheckDate(temp);
                    Birthday = temp;
                    OnPropertyChanged(nameof(IsAdult));
                    OnPropertyChanged(nameof(IsBirthday));
                    UpdateSigns();
                }
                catch
                {
                   
                }
            }
        }

        public bool IsAdult
        {
            get { return DateTime.Today.Year - _birthday?.Year >= 18; }
        }

        public WestZodiac SunSign
        {
            get { return _signs.WestZodiacSign; }
        }

        public ChineseZodiac ChineseSign
        {
            get { return _signs.ChineseZodiacSign; }
        }

        public bool IsBirthday
        {
            get { return DateTime.Today.Day == _birthday?.Day && DateTime.Today.Month == _birthday?.Month; }
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

        #region Constructors
        public Person(string name, string surname, string email, DateTime? birthday)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthday = birthday;
            _signs.Date = _birthday;
            UpdateSigns();
        }
        #endregion

        private async void UpdateSigns()
        {
            await Task.Run(() => UpdateSunSign());
            await Task.Run(() => UpdateChineseSign());
        }

        public void CheckDate(DateTime? date)
        {
            if ((DateTime.Today - date)?.TotalMilliseconds< 0)
                throw new FutureDateException(date);
            if ((date - DateTime.Today.AddYears(-135))?.TotalMilliseconds< 0)
                throw new LongPastDateException(date);
        }

        public void CheckEmail(string email)
        {
            Regex rgx = new Regex("\\w+@\\w+[.\\w+]{1,}");
            if (!rgx.IsMatch(email))
                throw new WrongEmailException();
        }

        public void UpdateSunSign()
        {
            _signs.UpdateWestZodiac();
            OnPropertyChanged(nameof(SunSign));
        }

        public void UpdateChineseSign()
        {
            _signs.UpdateChineseZodiac();
            OnPropertyChanged(nameof(ChineseSign));
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
