using GrinScootersClone.Interfaces;
using GrinScootersClone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace GrinScootersClone.ViewModels
{
    public class TripMapViewModel : BaseViewModel, IAsyncInitialization
    {
        public Task Initialization { get; }

        private readonly IApi _api;
        private readonly INavigation _navigation;

        public static Map MyMap;

        private MapStyleModel _mapStyle;
        public MapStyleModel MapStyles
        {
            get => _mapStyle;
            set => RaiseIfPropertyChanged(ref _mapStyle, value);
        }

        public TripMapViewModel(INavigation navigation, IApi api)
        {
            _api = api;
            _navigation = navigation;

            MyMap = new Map();
            Initialization = InitializationAsync();
        }

        private async Task InitializationAsync()
        {
            await LoadMapStyleAsync();
            LoadMyPosition();
        }

        private async Task LoadMapStyleAsync()
        {
            try
            {
                MapStyles = await _api.GetMapStyle();
                MyMap.MapStyle = MapStyle.FromJson(MapStyles.MapStyle);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }

        private void LoadMyPosition()
        {
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                 new Position(-23.604192, -46.524381), Distance.FromMeters(400)), true);
        }
    }
}
