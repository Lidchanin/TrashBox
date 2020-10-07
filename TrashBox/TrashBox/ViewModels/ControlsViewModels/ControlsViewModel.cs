using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TrashBox.Abstractions;
using TrashBox.Helpers;
using TrashBox.Models;
using TrashBox.Views.ControlsViews.DonutChart;
using TrashBox.Views.ControlsViews.GradientProgressBar;
using TrashBox.Views.ControlsViews.GradientRadialProgressBar;
using Xamarin.Forms;

namespace TrashBox.ViewModels.ControlsViewModels
{
    public class ControlsViewModel : BaseViewModel
    {
        public ICommand GoToPageCommand { get; }

        public static readonly IList<PageInfo> PagesInfos;

        static ControlsViewModel()
        {
            PagesInfos = new List<PageInfo>
            {
                new PageInfo
                {
                    Title = Constants.Texts.DonutCharts,
                    Description = Constants.Texts.DonutChartsDescription,
                    IconResourceName = Constants.EmbeddedImages.DonutChart,
                    Route = nameof(DonutChartTabbedPage)
                },
                new PageInfo
                {
                    Title = Constants.Texts.ProgressBars,
                    Description = Constants.Texts.ProgressBarsDescription,
                    IconResourceName = Constants.EmbeddedImages.ProgressBar,
                    Route = nameof(GradientProgressBarTabbedPage)
                },
                new PageInfo
                {
                    Title = Constants.Texts.RadialProgressBars,
                    Description = Constants.Texts.RadialProgressBarsDescription,
                    IconResourceName = Constants.EmbeddedImages.RadialProgressBar,
                    Route = nameof(GradientRadialProgressBarTabbedPage)
                },
            };
        }

        public ControlsViewModel()
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