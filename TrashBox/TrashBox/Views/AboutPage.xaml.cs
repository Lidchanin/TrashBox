using TrashBox.ViewModels;

namespace TrashBox.Views
{
    public partial class AboutPage
    {
        public AboutPage()
        {
            BindingContext = new AboutViewModel();

            InitializeComponent();
        }
    }
}