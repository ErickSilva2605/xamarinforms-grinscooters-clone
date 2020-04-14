using GrinScootersClone.Services;
using GrinScootersClone.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrinScootersClone.Views.Trip
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TripMapView : ContentPage
    {
        public TripMapView()
        {
            InitializeComponent();

            map.UiSettings.ZoomControlsEnabled = false;
            map.UiSettings.RotateGesturesEnabled = false;
            BindingContext = new TripMapViewModel(Navigation, ApiService.Instance);
            TripMapViewModel.MyMap = map;

            map.CameraIdled += async (sender, e) =>
            {
                Searching.IsVisible = true;

                await Task.Delay(300);

                Searching.IsVisible = false;

            };
        }
    }
}