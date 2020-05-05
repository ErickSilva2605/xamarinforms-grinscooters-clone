using Xamarin.Forms;

namespace GrinScootersClone.Controls
{
    public class CustomFrame : Frame
    {
        public static readonly BindableProperty ElevationProperty =
            BindableProperty.Create(
                nameof(Elevation), 
                typeof(float), 
                typeof(CustomFrame),
                4.0f
            );

        public float Elevation
        {
            get => (float)GetValue(ElevationProperty);
            set => SetValue(ElevationProperty, value);
        }
    }
}
