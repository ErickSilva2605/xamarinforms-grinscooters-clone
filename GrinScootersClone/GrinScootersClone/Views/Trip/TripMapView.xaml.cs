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
            BindingContext = new TripMapViewModel(Navigation, ApiService.Instance);
        }
    }
}