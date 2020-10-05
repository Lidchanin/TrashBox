using TrashBox.ViewModels.DesignsViewModels;

namespace TrashBox.Views.DesignsViews
{
    public partial class DesignsPage
    {
        public DesignsPage()
        {
            BindingContext = new DesignsViewModel();

            InitializeComponent();
        }
    }
}