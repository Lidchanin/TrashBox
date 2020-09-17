using TrashBox.ViewModels.ControlsViewModels;

namespace TrashBox.Views.ControlsPages
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