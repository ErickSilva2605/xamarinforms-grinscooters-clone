using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GrinScootersClone.ViewModels
{
    public class TripScannerViewModel : BaseViewModel
    {
        #region Fields

        private readonly INavigation _navigation;

        #endregion

        #region Commands

        public Command CloseCommand { get; private set; }

        #endregion

        #region Constructors

        public TripScannerViewModel(INavigation navigation)
        {
            _navigation = navigation;

            CloseCommand = new Command(
                async () => await NavigateToBackAsync()
            );
        }

        #endregion

        #region Methods

        private async Task NavigateToBackAsync()
        {
            await _navigation.PopAsync();
        }

        #endregion
    }
}
