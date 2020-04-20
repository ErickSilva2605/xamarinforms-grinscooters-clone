using GrinScootersClone.Interfaces;
using GrinScootersClone.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GrinScootersClone.ViewModels
{
    public class ProfileViewModel : BaseViewModel, IInitialize
    {
        public Task Initialization { get; }

        private readonly INavigation _navigation;
        private readonly IApi _api;

        private AccountModel _account;
        public AccountModel Account
        {
            get => _account;
            set => RaiseIfPropertyChanged(ref _account, value);
        }

        private IList<MenuModel> _menus;
        public IList<MenuModel> Menus
        {
            get => _menus;
            set => RaiseIfPropertyChanged(ref _menus, value);
        }

        public ProfileViewModel(INavigation navigation, IApi api)
        {
            _api = api;
            _navigation = navigation;

            Initialization = InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            await LoadAccountAsync();
            await LoadMenusAsync();
        }

        private async Task LoadAccountAsync()
        {
            try
            {
                Account = await _api.GetAccount();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }

        private async Task LoadMenusAsync()
        {
            try
            {
                var menus = await _api.GetMenus();
                Menus = new List<MenuModel>(menus);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }
    }
}
