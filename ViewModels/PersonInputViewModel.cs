using _01Burliai.Tools;

namespace _01Burliai.ViewModels
{
    class PersonInputViewModel
    {
        #region Fields


        #region Commands
        private RelayCommand<object> _proceedCommand;
        #endregion
        #endregion

        #region Properties
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
            return false;
        }
    }
}
