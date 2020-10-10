using System.ComponentModel;
using TrashBox.Controls.BorderlessControls;
using TrashBox.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessTimePicker), typeof(BorderlessTimePickerRenderer))]

namespace TrashBox.iOS.Renderers
{
    public class BorderlessTimePickerRenderer : TimePickerRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control?.Layer != null)
            {
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}