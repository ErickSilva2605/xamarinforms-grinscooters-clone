using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GrinScootersClone.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RaiseIfPropertyChanged<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(property, value))
                return;

            property = value;
            OnPropertyChanged(propertyName);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => RaiseIfPropertyChanged(ref _isBusy, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => RaiseIfPropertyChanged(ref _title, value);
        }

        private string _navArrow;
        public string NavArrow
        {
            get => _navArrow;
            set => RaiseIfPropertyChanged(ref _navArrow, value);
        }

        private string _navBackgroundColor;
        public string NavBackgroundColor
        {
            get => _navBackgroundColor;
            set => RaiseIfPropertyChanged(ref _navBackgroundColor, value);
        }
        
        private bool _navBarButtonVisible;
        public bool NavBarButtonVisible
        {
            get => _navBarButtonVisible;
            set => RaiseIfPropertyChanged(ref _navBarButtonVisible, value);
        }

        private string _helpCenterUrl;
        public string HelpCenterUrl
        {
            get => _helpCenterUrl;
            set => RaiseIfPropertyChanged(ref _helpCenterUrl, value);
        }
    }
}
