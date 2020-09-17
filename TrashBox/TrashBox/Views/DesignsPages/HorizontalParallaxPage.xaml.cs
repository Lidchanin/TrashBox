using TrashBox.ViewModels.DesignsViewModels;

namespace TrashBox.Views.DesignsPages
{
    public partial class HorizontalParallaxPage
    {
        public HorizontalParallaxPage()
        {
            BindingContext = new HorizontalParallaxViewModel();

            InitializeComponent();
        }
    }
}