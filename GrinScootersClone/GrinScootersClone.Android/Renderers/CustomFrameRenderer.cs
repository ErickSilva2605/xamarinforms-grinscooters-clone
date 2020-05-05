using System.ComponentModel;
using Android.Content;
using Android.Support.V4.View;
using GrinScootersClone.Controls;
using GrinScootersClone.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AC = Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace GrinScootersClone.Droid.Renderers
{
    public class CustomFrameRenderer : AC.FrameRenderer
    {
        public CustomFrameRenderer(Context context) 
            : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            UpdateElevation();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "Elevation")
                UpdateElevation();
        }

        private void UpdateElevation()
        {
            var customFrame = (CustomFrame)Element;

            Control.StateListAnimator = new Android.Animation.StateListAnimator();

            ViewCompat.SetElevation(this, customFrame.Elevation);
            ViewCompat.SetElevation(Control, customFrame.Elevation);
        }
    }
}