using TrashBox.ViewModels;

namespace TrashBox.Views.GradientProgressBarPages
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