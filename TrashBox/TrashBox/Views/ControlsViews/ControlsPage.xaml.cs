using TrashBox.ViewModels.ControlsViewModels;

namespace TrashBox.Views.ControlsViews
{
    public partial class ControlsPage
    {
        public ControlsPage()
        {
            BindingContext = new ControlsViewModel();

            InitializeComponent();
        }
    }
}