using TrashBox.ViewModels.ControlsViewModels;

namespace TrashBox.Views.ControlsViews.GradientRadialProgressBar
{
    public partial class GradientRadialProgressBarExperimentPage
    {
        public GradientRadialProgressBarExperimentPage()
        {
            BindingContext = new GradientRadialProgressBarViewModel();

            InitializeComponent();
        }
    }
}