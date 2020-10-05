using TrashBox.ViewModels.DesignsViewModels;

namespace TrashBox.Views.DesignsViews.MKDemo
{
    public partial class MKDemoPage
    {
        public MKDemoPage()
        {
            BindingContext = new MKDemoViewModel();

            InitializeComponent();
        }
    }
}