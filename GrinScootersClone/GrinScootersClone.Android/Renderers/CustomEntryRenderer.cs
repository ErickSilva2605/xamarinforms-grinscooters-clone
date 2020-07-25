using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using GrinScootersClone.Controls;
using GrinScootersClone.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace GrinScootersClone.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null && e.NewElement == null)
                return;

            var view = (CustomEntry)Element;

            if (view.HasBorder)
            {
                var _gradientBackground = new GradientDrawable();


                _gradientBackground.SetShape(ShapeType.Rectangle);
                _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());

                view.BackgroundColor = Color.Transparent;

                _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                _gradientBackground.SetCornerRadius(
                        DpToPixels(this.Context, Convert.ToSingle(view.BorderRadius)));

                Control.SetBackground(_gradientBackground);
            }

            if (view.HasPadding)
            {
                Control.SetPadding(
                    (int)DpToPixels(this.Context, Convert.ToSingle(view.Padding.Left)),
                    (int)DpToPixels(this.Context, Convert.ToSingle(view.Padding.Top)),
                    (int)DpToPixels(this.Context, Convert.ToSingle(view.Padding.Right)),
                    (int)DpToPixels(this.Context, Convert.ToSingle(view.Padding.Bottom))
                );
            }
            else
            {
                Control.SetPadding(
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)),
                    Control.PaddingTop,
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)), 
                    Control.PaddingBottom
                );
            }
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}