using TrashBox.ViewModels;

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