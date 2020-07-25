using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GrinScootersClone.Controls
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty HasBorderProperty =
            BindableProperty.Create(
                nameof(HasBorder),
                typeof(bool),
                typeof(CustomEntry),
                false
            );

        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(
                nameof(BorderWidth),
                typeof(int),
                typeof(CustomEntry),
                1
            );

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(
                nameof(BorderColor),
                typeof(Color),
                typeof(CustomEntry),
                Color.Gray
            );

        public static readonly BindableProperty BorderRadiusProperty =
            BindableProperty.Create(
                nameof(BorderRadius),
                typeof(int),
                typeof(CustomEntry),
                1
            );

        public static readonly BindableProperty HasPaddingProperty =
            BindableProperty.Create(
                nameof(HasPadding),
                typeof(bool),
                typeof(CustomEntry),
                false
            );

        public static readonly BindableProperty PaddingProperty =
            BindableProperty.Create(
                nameof(Padding),
                typeof(Thickness),
                typeof(CustomEntry),
                new Thickness(0,0,0,0)
            );

        public bool HasBorder
        {
            get => (bool)GetValue(HasBorderProperty);
            set => SetValue(HasBorderProperty, value);
        }

        public int BorderWidth 
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value); 
        }

        public Color BorderColor 
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public int BorderRadius 
        {
            get => (int)GetValue(BorderRadiusProperty);
            set => SetValue(BorderRadiusProperty, value);
        }

        public bool HasPadding
        {
            get => (bool)GetValue(HasPaddingProperty);
            set => SetValue(HasPaddingProperty, value); 
        }

        public Thickness Padding 
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value); 
        }
    }
}
