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
        #region Fields

        private readonly INavigation _navigation;
        private readonly IApi _api;

        private string _title;
        private AccountModel _account;
        private IList<MenuModel> _menus;

        #endregion

        #region Properties

        public Task Initialization { get; }

        public string Title
        {
            get => _title;
            set => RaiseIfPropertyChanged(ref _title, value);
        }

        public AccountModel Account
        {
            get => _account;
            set => RaiseIfPropertyChanged(ref _account, value);
        }

        public IList<MenuModel> Menus
        {
            get => _menus;
            set => RaiseIfPropertyChanged(ref _menus, value);
        }

        #endregion

        #region Constructors

        public ProfileViewModel(INavigation navigation, IApi api)
        {
            _api = api;
            _navigation = navigation;

            Initialization = InitializeAsync();
        }

        #endregion

        #region Methods
        public async Task InitializeAsync()
        {
            await LoadProfileAsync();
            await LoadMenusAsync();
        }

        private async Task LoadProfileAsync()
        {
            try
            {
                Account = await _api.GetAccount();
                Title = GetTitle(Account.Name);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }

        private string GetTitle(string name)
        {
            return name.Split(' ')[0];
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

        #endregion
    }
}
