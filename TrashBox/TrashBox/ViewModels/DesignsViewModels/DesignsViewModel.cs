using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TrashBox.Abstractions;
using TrashBox.Helpers;
using TrashBox.Models;
using TrashBox.Views.DesignsViews.CasioShop;
using TrashBox.Views.DesignsViews.MKDemo;
using Xamarin.Forms;

namespace TrashBox.ViewModels.DesignsViewModels
{
    public class DesignsViewModel : BaseViewModel
    {
        public ICommand GoToPageCommand { get; }

        public static readonly IList<PageInfo> PagesInfos;

        static DesignsViewModel()
        {
            PagesInfos = new List<PageInfo>
            {
                new PageInfo
                {
                    Title = Constants.Texts.MKDemo,
                    Description = Constants.Texts.MKDemoDescription,
                    IconResourceName = Constants.EmbeddedImages.MKLogo2,
                    Route = nameof(MKDemoPage),
                    TitleFontFamily = Constants.EmbeddedFonts.MKTitle,
                    DescriptionFontFamily = Constants.EmbeddedFonts.MK4
                },
                new PageInfo
                {
                    Title = Constants.Texts.CasioShop,
                    Description = Constants.Texts.CasioShopDescription,
                    IconResourceName = Constants.EmbeddedImages.ShoppingCart,
                    Route = nameof(CasioShopPage)
                }
            };
        }

        public DesignsViewModel()
        {
            GoToPageCommand = new Command(async parameter => await GoToPageAsync(parameter));
        }

        private async Task GoToPageAsync(object parameter)
        {
            if (IsBusy || !(parameter is PageInfo pageInfo))
            {
                return;
            }

            IsBusy = true;

            try
            {
                await ShellNavigationHelper.GoToAsync(pageInfo.Route);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}