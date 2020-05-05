using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GrinScootersClone.ViewModels
{
    public class HelpCenterViewModel : BaseViewModel
    {
        #region Fields

        private readonly INavigation _navigation;
        private readonly string _helpUrl = "https://support.ongrin.com/hc/pt-br";
        
        #endregion

        #region Commands

        public Command GoBackCommand { get; private set; }

        #endregion

        #region Constructors

        public HelpCenterViewModel(INavigation navigation)
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
            Title = "Central de Ajuda";
            NavArrow = "navbar_arrow_black";
            NavBackgroundColor = "#F5F5F5";
            HelpCenterUrl = _helpUrl;
            NavBarButtonVisible = true;
        }

        private async Task NavigateToBackAsync()
        {
            await _navigation.PopModalAsync();
        }

        #endregion
    }
}
