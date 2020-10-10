using Android.Content;
using TrashBox.Controls.BorderlessControls;
using TrashBox.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessTimePicker), typeof(BorderlessTimePickerRenderer))]

namespace TrashBox.Droid.Renderers
{
    public class BorderlessTimePickerRenderer : TimePickerRenderer
    {
        public BorderlessTimePickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Background = null;

                var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                layoutParams.SetMargins(0, 0, 0, 0);
                LayoutParameters = layoutParams;
                Control.LayoutParameters = layoutParams;
                Control.SetPadding(0, 0, 0, 0);
                SetPadding(0, 0, 0, 0);
            }
        }
    }
}