using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GrinScootersClone.ViewModels
{
    public class AddBalanceViewModel : BaseViewModel
    {
        #region Fields

        private readonly INavigation _navigation;

        #endregion

        #region Commands

        public Command GoBackCommand { get; private set; }

        #endregion

        #region Constructors

        public AddBalanceViewModel(INavigation navigation)
        {
            _navigation = navigation;

            GoBackCommand = new Command(
                async () => await NavigateToBackAsync()
            );

            LoadNavBar();
        }

        #endregion

        #region Methods

        private void LoadNavBar()
        {
            Title = "Minha Carteira";
            NavArrow = "navbar_arrow_black";
            NavBackgroundColor = "#F5F5F5";
            NavBarButtonVisible = true;
        }

        private async Task NavigateToBackAsync()
        {
            await _navigation.PopModalAsync();
        }

        #endregion
    }
}
