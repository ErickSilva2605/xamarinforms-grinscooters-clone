using GrinScootersClone.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrinScootersClone.Views.Wallet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBalanceView : ContentPage
    {
        private Frame _defaultSelected;
        private bool _isFirstAppear = true;

        public AddBalanceView()
        {
            InitializeComponent();
            BindingContext = new AddBalanceViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_isFirstAppear)
                SelectFirst();

            _isFirstAppear = false;
        }

        private void SelectFirst()
        {
            int index = 0;
            foreach (var view in GridSection.Children)
            {
                if (view is Frame frame)
                {
                    if (index++ == 1)
                    {
                        GoToStateSelected(frame);
                        _defaultSelected = frame;
                        continue;
                    }

                    GoToStateUnSelected(frame);
                }
            }

            GoToStatePopSelected();
        }

        private void OnTapped(object sender, EventArgs eventArgs)
        {
            if (sender is Frame senderFrame)
            {
                foreach (var view in GridSection.Children)
                {
                    if (view is Frame frame)
                    {
                        if (senderFrame == frame)
                        {
                            GoToStateSelected(frame);
                            continue;
                        }

                        GoToStateUnSelected(frame);
                    }
                }

                if (senderFrame == _defaultSelected)
                    GoToStatePopSelected();
                else
                    GoToStatePopUnSelected();
            }
        }

        private void GoToStateSelected(Frame frame)
        {
            VisualStateManager.GoToState(frame, "Selected");

            if (frame.Children[0] is Label label)
            {
                SetBalance(label.Text);
                VisualStateManager.GoToState(label, "Selected");
            }
        }

        private void GoToStateUnSelected(Frame frame)
        {
            VisualStateManager.GoToState(frame, "UnSelected");

            if (frame.Children[0] is Label label)
            {
                VisualStateManager.GoToState(label, "UnSelected");
            }
        }

        private void GoToStatePopSelected()
        {
            VisualStateManager.GoToState(PopularFrame, "Selected");
        }

        private void GoToStatePopUnSelected()
        {
            VisualStateManager.GoToState(PopularFrame, "UnSelected");
        }

        private void SetBalance(string value)
        {
            PurchaseBtn.Text = $"Confirme a compra {value}";
            RechargeSpan.Text = value;
        }
    }
}