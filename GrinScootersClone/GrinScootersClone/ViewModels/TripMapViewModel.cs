using GrinScootersClone.Interfaces;
using GrinScootersClone.Models;
using GrinScootersClone.Views.Trip;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using static Xamarin.Essentials.Permissions;
using GoogleMaps = Xamarin.Forms.GoogleMaps;

namespace GrinScootersClone.ViewModels
{
    public class TripMapViewModel : BaseViewModel, IInitialize
    {
        #region Fields

        private readonly IApi _api;
        private readonly INavigation _navigation;

        private readonly double _defaultLatitude = -23.5504533;
        private readonly double _defaultLongitude = -46.6360999;

        private MapStyleModel _mapStyle;
        public static GoogleMaps.Map MyMap;

        #endregion

        #region Properties

        public MapStyleModel MapStyles
        {
            get => _mapStyle;
            set => RaiseIfPropertyChanged(ref _mapStyle, value);
        }

        public ObservableCollection<Pin> Pins { get; set; }

        #endregion

        #region Commands

        public Command GoToMyLocationCommand { get; private set; }
        public Command GoToScannerView { get; private set; }

        #endregion

        #region Constructors

        public TripMapViewModel(INavigation navigation, IApi api)
        {
            _api = api;
            _navigation = navigation;

            MyMap = new GoogleMaps.Map();

            GoToMyLocationCommand = new Command(
                async () => await MoveToCurrentPosition()
            );

            GoToScannerView = new Command(
                async () => await NavigateToAsync()
            );
        }

        #endregion

        #region Methods

        public async Task InitializeAsync()
        {
            LoadInitialLocation();

            await LoadMapStyleAsync();
            await MoveToCurrentPosition();
            await GetPlaces();
        }

        private void LoadInitialLocation()
        {
            MyMap.InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(
                GetPosition(_defaultLatitude, _defaultLongitude), 2);
        }

        private async Task LoadMapStyleAsync()
        {
            try
            {
                MapStyles = await _api.GetMapStyle();
                MyMap.MapStyle = MapStyle.FromJson(MapStyles.MapStyle);
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
                location = new Location(_defaultLatitude, _defaultLongitude);

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                 GetPosition(location.Latitude, location.Longitude), Distance.FromMeters(400)));
        }

        public async Task<Location> GetLocationAsync()
        {
            var status = await CheckAndRequestPermissionAsync(new LocationWhenInUse());
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

        private async Task GetPlaces()
        {
            try
            {
                var places = await _api.GetPlaces();
                LoadPins(places);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void LoadPins(IList<PlaceModel> places)
        {
            foreach (var place in places)
            {
                Pins.Add(new Pin
                {
                    Label = place.Description,
                    Position = GetPosition(place.Latitude, place.Longitude),
                    Icon = BitmapDescriptorFactory.FromBundle(place.Icon)
                });
            }
        }

        private Position GetPosition(double latitude, double longitude)
        {
            return new
                Position(latitude, longitude);
        }

        private async Task NavigateToAsync()
        {
            await _navigation.PushAsync(new TripScannerView());
        }

        #endregion
    }
}
