using TrashBox.ViewModels.DesignsViewModels;

namespace TrashBox.Views.DesignsPages
{
    public partial class HorizontalParallaxCarouselPage
    {
        public HorizontalParallaxCarouselPage()
        {
            BindingContext = new HorizontalParallaxCarouselViewModel();

            InitializeComponent();
        }
    }
}