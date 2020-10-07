using TrashBox.ViewModels.ControlsViewModels;

namespace TrashBox.Views.ControlsViews.DonutChart
{
    public partial class DonutChartVariant1Page
    {
        public DonutChartVariant1Page()
        {
            BindingContext = new DonutChartViewModel();

            InitializeComponent();
        }
    }
}