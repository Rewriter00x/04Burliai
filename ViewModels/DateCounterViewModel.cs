using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        public string WestZodiacSign
        {
            get { return _signs.WestZodiacSign; }
        }

        public string ChineseZodiacSign
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
            if (years < 0 || years > 135)
            {
                MessageBox.Show("Invalid year");
                return;
            }
            if (DateTime.Today.Day == Date?.Day && DateTime.Today.Month == Date?.Month) MessageBox.Show("Happy Birthday!");
            _signs.UpdateWestZodiac();
            _signs.UpdateChineseZodiac();
            OnPropertyChanged("Age");
            OnPropertyChanged("WestZodiacSign");
            OnPropertyChanged("ChineseZodiacSign");
        }

        private bool CanExecute()
        {
            return _signs.Date != null;
        }
    }
}
