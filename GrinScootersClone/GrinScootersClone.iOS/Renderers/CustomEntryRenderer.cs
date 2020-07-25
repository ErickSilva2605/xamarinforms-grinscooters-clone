using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using GrinScootersClone.Controls;
using GrinScootersClone.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace GrinScootersClone.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null && e.NewElement == null)
                return;

            var view = (CustomEntry)Element;

            Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));
            Control.LeftViewMode = UITextFieldViewMode.Always;
            Control.ReturnKeyType = UIReturnKeyType.Done;


            if (view.HasBorder)
            {
                Control.Layer.CornerRadius = Convert.ToSingle(view.BorderRadius);
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                Control.Layer.BorderWidth = view.BorderWidth;
                Control.ClipsToBounds = true;
            }
        }
    }
}