using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using _01Burliai.Annotations;
using _01Burliai.Models;
using _01Burliai.Tools;

namespace _01Burliai.ViewModels
{
    class DateCounterViewModel : INotifyPropertyChanged
    {
        #region Fields
        private ZodiacSigns _signs = new ZodiacSigns();

        #region Commands
        private RelayCommand<object> _outputCommand;
        #endregion
        #endregion

        #region Properties
        public DateTime? Date
        {
            get { return _signs.Date; }
            set { _signs.Date = value; }
        }

        public int Age
        {
            get { return _signs.Age; }
        }

        public WestZodiac WestZodiacSign
        {
            get { return _signs.WestZodiacSign; }
        }

        public ChineseZodiac ChineseZodiacSign
        {
            get { return _signs.ChineseZodiacSign; }
        }

        public RelayCommand<object> OutputCommand
        {
            get
            {
                return _outputCommand ??= new RelayCommand<object>(_=>Output(), _=>CanExecute());
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

        private void Output()
        {
            int years = Age;
            //TODO власне через це і можна вибрати дату в майбутньому, так як в такому випадку Age буде 0
            if (years > 135)
            {
                MessageBox.Show("Invalid year");
                return;
            }
            if (DateTime.Today.Day == Date?.Day && DateTime.Today.Month == Date?.Month) 
                MessageBox.Show("Happy Birthday!");
            _signs.UpdateWestZodiac();
            _signs.UpdateChineseZodiac();
            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(WestZodiacSign));
            OnPropertyChanged(nameof(ChineseZodiacSign));
        }

        private bool CanExecute()
        {
            return _signs.Date != null;
        }
    }
}
