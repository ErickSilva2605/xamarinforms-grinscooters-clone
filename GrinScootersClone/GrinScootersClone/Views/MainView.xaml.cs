using GrinScootersClone.Views.Profile;
using GrinScootersClone.Views.Trip;
using GrinScootersClone.Views.Wallet;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using TabbedPage = Xamarin.Forms.TabbedPage;

namespace GrinScootersClone.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainView : TabbedPage
    {
        public MainView()
        {
            InitializeComponent();

            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Android>().DisableSmoothScroll();
            On<Android>().DisableSwipePaging();

            Children.Add(new TripMapView());
            Children.Add(new WalletView());
            Children.Add(new ProfileView());
        }
    }
}
