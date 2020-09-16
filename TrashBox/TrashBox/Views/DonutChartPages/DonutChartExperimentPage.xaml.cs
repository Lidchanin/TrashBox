using TrashBox.ViewModels;

namespace TrashBox.Views.DonutChartPages
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