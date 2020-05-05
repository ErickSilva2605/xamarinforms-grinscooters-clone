using GrinScootersClone.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrinScootersClone.Views.HelpCenter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpCenterView : ContentPage
    {
        public HelpCenterView()
        {
            InitializeComponent();
            BindingContext = new HelpCenterViewModel(Navigation);
        }
    }
}