using Fast_Do.Droid.Effects;
using System;
using Xamarin.Forms;
using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Fast_Do")]
[assembly: ExportEffect(typeof(DroidBackgroundEntryEffect), "BackgroundEffect")]
namespace Fast_Do.Droid.Effects
{
    public class DroidBackgroundEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var nativeEditText = (global::Android.Widget.EditText)Control;
                var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
                shape.Paint.Color = Xamarin.Forms.Color.Black.ToAndroid();
                shape.Paint.SetStyle(Paint.Style.Stroke);
                nativeEditText.Background = shape;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {

        }
    }
}