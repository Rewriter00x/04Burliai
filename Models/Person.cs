using System;

namespace _01Burliai.Models
{
    class Person
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
            set { _email = value; }
        }

        public DateTime? Birthday
        {
            get { return _birthday; }
            set { 
                _birthday = value;
                _signs.Date = _birthday;
            }
        }

        public bool isAdult
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

        public bool isBirthday
        {
            get { return DateTime.Today.Day == _birthday?.Day && DateTime.Today.Month == _birthday?.Month; }
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
        }

        // We only press "Proceed" if all fields are not null, so only top constructor will be executed

        public Person(string name, string surname, string email) : this(name, surname, email, null) { }
        public Person(string name, string surname, DateTime birthdate) : this(name, surname, "No Email", birthdate) { }
        #endregion

        public void UpdateSunSign()
        {
            _signs.UpdateWestZodiac();
        }

        public void UpdateChineseSign()
        {
            _signs.UpdateChineseZodiac();
        }
    }
}
