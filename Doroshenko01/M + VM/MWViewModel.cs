using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Doroshenko01
{
    internal class MWViewModel : INotifyPropertyChanged
    {
        private DateTime _date = DateTime.Today;
        private string _age;
        private string _wZodiac;
        private string _cZodiac;
        private bool _canExecute;

        private RelayCommand _calculateAgeCommand;

        private readonly Action<bool> _showLoaderAction;

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get { return _age; }
            private set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string WesternZodiac
        {
            get { return _wZodiac; }
            private set
            {
                _wZodiac = value;
                OnPropertyChanged();
            }
        }

        public string ChineseZodiac
        {
            get { return _cZodiac; }
            private set
            {
                _cZodiac = value;
                OnPropertyChanged();
            }
        }

        internal MWViewModel(Action<bool> showLoader)
        {
            _showLoaderAction = showLoader;
            CanExecute = true;
        }

        public bool CanExecute
        {
            get { return _canExecute; }
            private set
            {
                _canExecute = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CalculateAgeCommand
        {
            get { return _calculateAgeCommand ?? (_calculateAgeCommand = new RelayCommand(AgeCalcImpl)); }
        }

        private async void AgeCalcImpl(object o)
        {
            _showLoaderAction.Invoke(true);
            ClearValues();
            await Task.Run(() =>
            {
                UserManager.CurrentUser = UserCalcAge.CreateUser(_date);
                Thread.Sleep(2000);
            });

            if (UserManager.CurrentUser == null)
                MessageBox.Show($"Entered date - {_date:d} is invalid.");
            else
            {
                if (_date.DayOfYear == DateTime.Today.DayOfYear)
                    MessageBox.Show("Happy Birthday!");
                Age = $"You are {UserManager.CurrentUser.Age}  y.o.";
                WesternZodiac = $"By western zodiac system your sign is {UserManager.CurrentUser.WesternZodiac}";
                ChineseZodiac = $"By chinese zodiac system your sign is {UserManager.CurrentUser.ChineseZodiac}";
            }
            CanExecute = true;
            _showLoaderAction.Invoke(false);
        }

        private void ClearValues()
        {
            CanExecute = false;
            Age = "";
            WesternZodiac = "";
            ChineseZodiac = "";
        }

        #region Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}