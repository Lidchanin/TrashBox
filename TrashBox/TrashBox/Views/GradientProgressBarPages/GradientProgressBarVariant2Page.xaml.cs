using TrashBox.ViewModels;

namespace TrashBox.Views.GradientProgressBarPages
{
    public partial class GradientProgressBarVariant2Page
    {
        public GradientProgressBarVariant2Page()
        {
            BindingContext = new GradientProgressBarViewModel();

            InitializeComponent();
        }
    }
}