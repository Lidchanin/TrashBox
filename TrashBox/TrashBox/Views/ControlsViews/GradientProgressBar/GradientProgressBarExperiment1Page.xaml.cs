using TrashBox.ViewModels.ControlsViewModels;

namespace TrashBox.Views.ControlsViews.GradientProgressBar
{
    public partial class GradientProgressBarExperiment1Page
    {
        public GradientProgressBarExperiment1Page()
        {
            BindingContext = new GradientProgressBarViewModel();

            InitializeComponent();
        }
    }
}