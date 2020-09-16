using TrashBox.ViewModels;

namespace TrashBox.Views.GradientRadialProgressBarPages
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