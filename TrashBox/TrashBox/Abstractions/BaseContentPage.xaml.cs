using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace TrashBox.Abstractions
{
    public partial class BaseContentPage
    {
        public BaseContentPage()
        {
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            InitializeComponent();
        }
    }
}