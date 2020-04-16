using Android.Content;
using Android.Support.Design.Widget;
using GrinScootersClone.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TabPagRenderer = Xamarin.Forms.Platform.Android.AppCompat.TabbedPageRenderer;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]
namespace GrinScootersClone.Droid.Renderers
{
    public class CustomTabbedPageRenderer : TabPagRenderer
    {
        private readonly int _minimumHeight = 190;
        private BottomNavigationView _bottomNavigationView;

        public CustomTabbedPageRenderer(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var relativeLayout = base.GetChildAt(0) as Android.Widget.RelativeLayout;

                _bottomNavigationView = relativeLayout.GetChildAt(1) as BottomNavigationView;
                _bottomNavigationView.SetShiftMode(false, true);
                _bottomNavigationView.SetMinimumHeight(_minimumHeight);
            }
        }
    }
}