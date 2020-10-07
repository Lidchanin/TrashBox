using TrashBox.ViewModels.ControlsViewModels;

namespace TrashBox.Views.ControlsViews.DonutChart
{
    public partial class DonutChartVariant2Page
    {
        public DonutChartVariant2Page()
        {
            BindingContext = new DonutChartViewModel();
            
            InitializeComponent();
        }
    }
}