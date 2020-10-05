using TrashBox.ViewModels.ControlsViewModels;

namespace TrashBox.Views.ControlsViews.DonutChart
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