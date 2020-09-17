using TrashBox.ViewModels.DesignsViewModels;

namespace TrashBox.Views.DesignsPages
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