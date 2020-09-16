using TrashBox.ViewModels;

namespace TrashBox.Views
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