using TrashBox.ViewModels;

namespace TrashBox.Views.GradientProgressBarPages
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