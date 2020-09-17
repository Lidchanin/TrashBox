using TrashBox.ViewModels.ControlsViewModels;

namespace TrashBox.Views.ControlsPages.GradientProgressBarPages
{
    public partial class GradientProgressBarVariant2Page
    {
        public GradientProgressBarVariant2Page()
        {
            BindingContext = new GradientProgressBarViewModel();

            InitializeComponent();
        }
    }
}