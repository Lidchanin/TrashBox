using TrashBox.ViewModels.DesignsViewModels;

namespace TrashBox.Views.DesignsPages.MKDemo
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