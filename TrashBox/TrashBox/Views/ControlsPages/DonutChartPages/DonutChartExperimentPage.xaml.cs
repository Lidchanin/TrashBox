using TrashBox.ViewModels.ControlsViewModels;

namespace TrashBox.Views.ControlsPages.DonutChartPages
{
    public partial class DonutChartExperimentPage
    {
        public DonutChartExperimentPage()
        {
            BindingContext = new DonutChartViewModel();

            InitializeComponent();
        }
    }
}