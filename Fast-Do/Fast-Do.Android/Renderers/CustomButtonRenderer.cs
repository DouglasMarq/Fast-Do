using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Fast_Do.Droid;
using Fast_Do.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace Fast_Do.Droid.Renderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                Control.Touch -= CustomButtonOnTouch;
            }
            if (e.NewElement != null)
            {
                Control.Touch += CustomButtonOnTouch;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.Touch -= CustomButtonOnTouch;
            }
            base.Dispose(disposing);
        }

        private void CustomButtonOnTouch(object sender, TouchEventArgs touchEventArgs)
        {
            if (touchEventArgs.Event.Action == MotionEventActions.Down)
            {
                Element.ScaleTo(0.8, 125, Easing.CubicOut);
            }
            else if (touchEventArgs.Event.Action == MotionEventActions.Up)
            {
                Element.ScaleTo(1, 125, Easing.CubicIn);

                if (Element != null && Element.Command != null)
                {
                    Element.Command.Execute(Element.CommandParameter);
                }
            }
        }
    }
}