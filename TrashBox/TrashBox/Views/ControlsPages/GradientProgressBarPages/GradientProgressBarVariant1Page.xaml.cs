using TrashBox.ViewModels;

namespace TrashBox.Views.ControlsPages.GradientProgressBarPages
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