using TrashBox.ViewModels.DesignsViewModels;
using Xamarin.Forms;

namespace TrashBox.Views.DesignsViews.CasioShop
{
    public partial class CasioShopPage
    {
        public Thickness ContentMargin => new Thickness(45, -0.1 * App.ScreenHeight, -45, 0);

        public Thickness ContentInnerMargin =>
            new Thickness(20, 45 + 0.1 * App.ScreenHeight + 20, 45 + 20, 20);

        public double TransparentItemHeightRequest => 0.75 * App.ScreenWidth - 45;

        public double CarouselHeightRequest => 0.9 * App.ScreenHeight - 45;

        private readonly CasioShopViewModel _viewModel;

        public CasioShopPage()
        {
            BindingContext = _viewModel = new CasioShopViewModel();

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.Init();
        }
    }
}