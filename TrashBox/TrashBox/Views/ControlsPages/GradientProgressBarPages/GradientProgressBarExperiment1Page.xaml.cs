using TrashBox.ViewModels;

namespace TrashBox.Views.ControlsPages.GradientProgressBarPages
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