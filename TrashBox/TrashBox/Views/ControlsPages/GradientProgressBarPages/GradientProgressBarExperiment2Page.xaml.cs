using TrashBox.ViewModels.ControlsViewModels;

namespace TrashBox.Views.ControlsPages.GradientProgressBarPages
{
    public partial class GradientProgressBarExperiment2Page
    {
        public GradientProgressBarExperiment2Page()
        {
            BindingContext = new GradientProgressBarViewModel();

            InitializeComponent();
        }
    }
}