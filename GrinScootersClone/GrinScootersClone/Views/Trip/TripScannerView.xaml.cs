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
    public partial class TripScannerView : ContentPage
    {
        public TripScannerView()
        {
            InitializeComponent();
        }

        async void CloseModal(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}