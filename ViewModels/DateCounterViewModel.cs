using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using _01Burliai.Tools;

namespace _01Burliai.ViewModels
{
    class DateCounterViewModel
    {
        #region Fields
        

        #region Commands
        private RelayCommand<object> _countCommand;
        #endregion
        #endregion

        #region Properties
        public RelayCommand<object> CountCommand
        {
            get
            {
                return _countCommand ?? (_countCommand = new RelayCommand<object>(_=>Count(), _=>CanExecute()));
            }
        }
        #endregion

        private void Count()
        {
            MessageBox.Show("Success!");
        }

        private bool CanExecute()
        {
            return true;
        }
    }
}
