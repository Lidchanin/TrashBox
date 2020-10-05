using TrashBox.ViewModels.ControlsViewModels;

namespace TrashBox.Views.ControlsViews.GradientProgressBar
{
    public partial class GradientProgressBarVariant1Page
    {
        public GradientProgressBarVariant1Page()
        {
            BindingContext = new GradientProgressBarViewModel();

            InitializeComponent();
        }
    }
}