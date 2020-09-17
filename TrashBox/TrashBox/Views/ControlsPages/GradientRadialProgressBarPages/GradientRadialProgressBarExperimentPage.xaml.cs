using TrashBox.ViewModels.ControlsViewModels;

namespace TrashBox.Views.ControlsPages.GradientRadialProgressBarPages
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