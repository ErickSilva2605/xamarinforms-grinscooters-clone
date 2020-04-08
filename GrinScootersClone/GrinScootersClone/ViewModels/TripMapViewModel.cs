using GrinScootersClone.Interfaces;
using GrinScootersClone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GrinScootersClone.ViewModels
{
    public class TripMapViewModel : BaseViewModel, IAsyncInitialization
    {
        public Task Initialization { get; }

        private readonly IApi _api;
        private readonly INavigation _navigation;

        private MapStyleModel _mapStyle;
        public MapStyleModel MapStyle
        {
            get => _mapStyle;
            set => RaiseIfPropertyChanged(ref _mapStyle, value);
        }

        public TripMapViewModel(INavigation navigation, IApi api)
        {
            _api = api;
            _navigation = navigation;

            Initialization = InitializationAsync();
        }

        private async Task InitializationAsync()
        {
            await LoadMapStyleAsync();
        }

        private async Task LoadMapStyleAsync()
        {
            try
            {
                MapStyle = await _api.GetMapStyle();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }
    }
}
