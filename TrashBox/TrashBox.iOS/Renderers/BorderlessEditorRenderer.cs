using System.ComponentModel;
using TrashBox.Controls.BorderlessControls;
using TrashBox.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessEditor), typeof(BorderlessEditorRenderer))]

namespace TrashBox.iOS.Renderers
{
    public class BorderlessEditorRenderer : EditorRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control?.Layer == null)
            {
                return;
            }

            Control.Layer.BorderWidth = 0;
        }
    }
}