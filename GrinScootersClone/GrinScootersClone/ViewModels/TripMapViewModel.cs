using GrinScootersClone.Interfaces;
using GrinScootersClone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using GoogleMaps = Xamarin.Forms.GoogleMaps;
using static Xamarin.Essentials.Permissions;

namespace GrinScootersClone.ViewModels
{
    public class TripMapViewModel : BaseViewModel, IAsyncInitialization
    {
        public Task Initialization { get; }

        private readonly IApi _api;
        private readonly INavigation _navigation;

        public static GoogleMaps.Map MyMap;

        public Command GoToMyLocationCommand { get; private set; }

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

            MyMap = new GoogleMaps.Map();

            GoToMyLocationCommand = new Command(
                async () => await MoveToCurrentPosition()
            );

            Initialization = InitializationAsync();
        }

        private async Task InitializationAsync()
        {
            await LoadMapStyleAsync();
            await MoveToCurrentPosition();
        }

        private async Task LoadMapStyleAsync()
        {
            try
            {
                MapStyles = await _api.GetMapStyle();
                MyMap.MapStyle = GoogleMaps.MapStyle.FromJson(MapStyles.MapStyle);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private async Task MoveToCurrentPosition()
        {
            var location = await GetLocationAsync();

            if (location == null)
                location = new Location(-23.5504533, -46.6360999);

            MyMap.MoveToRegion(GoogleMaps.MapSpan.FromCenterAndRadius(
                 new GoogleMaps.Position(location.Latitude, location.Longitude), GoogleMaps.Distance.FromMeters(400)));
        }

        public async Task<Location> GetLocationAsync()
        {
            var status = await CheckAndRequestPermissionAsync(new Permissions.LocationWhenInUse());
            if (status != PermissionStatus.Granted)
            {
                MyMap.MyLocationEnabled = false;
                return null;
            }

            MyMap.MyLocationEnabled = true;
            return await Geolocation.GetLocationAsync();
        }

        public async Task<PermissionStatus> CheckAndRequestPermissionAsync<T>(T permission)
                    where T : BasePermission
        {
            var status = await permission.CheckStatusAsync();
            if (status != PermissionStatus.Granted)
            {
                status = await permission.RequestAsync();
            }

            return status;
        }
    }
}
