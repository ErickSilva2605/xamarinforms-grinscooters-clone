using GrinScootersClone.Interfaces;
using GrinScootersClone.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrinScootersClone.Views.Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactView : ContentPage
    {
        public ContactView()
        {
            InitializeComponent();
            BindingContext = new ContactViewModel(Navigation);
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