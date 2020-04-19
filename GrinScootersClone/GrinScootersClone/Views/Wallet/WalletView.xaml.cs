
using GrinScootersClone.Interfaces;
using GrinScootersClone.Services;
using GrinScootersClone.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrinScootersClone.Views.Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalletView : ContentPage
    {
        public WalletView()
        {
            InitializeComponent();
            BindingContext = new WalletViewModel(Navigation, ApiService.Instance);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await OnAppearingAsync();

        }

        private async Task OnAppearingAsync()
        {
            if (BindingContext is IInitialize viewModel)
            {
                await viewModel.InitializeAsync();
            }
        }
    }
}