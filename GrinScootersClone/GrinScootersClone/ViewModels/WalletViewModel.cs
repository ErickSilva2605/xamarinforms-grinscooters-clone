using GrinScootersClone.Interfaces;
using GrinScootersClone.Models;
using GrinScootersClone.Views.Wallet;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GrinScootersClone.ViewModels
{
    public class WalletViewModel : BaseViewModel, IInitialize
    {
        #region Fields

        private readonly IApi _api;
        private readonly INavigation _navigation;

        private WalletModel _wallet;

        #endregion

        #region Properties

        public WalletModel Wallet
        {
            get => _wallet;
            set => RaiseIfPropertyChanged(ref _wallet, value);
        }

        #endregion

        #region Commands

        public Command AddBalanceCommand { get; private set; }

        #endregion

        #region Constructors

        public WalletViewModel(INavigation navigation, IApi api)
        {
            _api = api;
            _navigation = navigation;

            AddBalanceCommand = new Command(
                async () => await NavigateToAddBalanceAsync()
            );

            LoadNavBar();
        }

        #endregion

        #region Methods

        private void LoadNavBar()
        {
            NavBackgroundColor = "#09D46B";
            NavArrow = "navbar_arrow_white";
            NavBarButtonVisible = false;
        }

        public async Task InitializeAsync()
        {
            await GetWallet();
        }

        private async Task GetWallet()
        {
            try
            {
                Wallet = await _api.GetWallet();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private async Task NavigateToAddBalanceAsync()
        {
            await _navigation.PushModalAsync(new AddBalanceView());
        }
        #endregion
    }
}
