using Android.Content;
using GrinScootersClone.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ButtonRenderer = Xamarin.Forms.Platform.Android.FastRenderers.ButtonRenderer;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustonButtonRenderer))]
namespace GrinScootersClone.Droid.Renderers
{
    public class CustonButtonRenderer : ButtonRenderer
    {
        public CustonButtonRenderer(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetAllCaps(false);
            }
        }
    }
}