using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TrashBox.Abstractions;
using TrashBox.Helpers;
using TrashBox.Views.DonutChartPages;
using TrashBox.Views.GradientProgressBarPages;
using TrashBox.Views.GradientRadialProgressBarPages;
using Xamarin.Forms;

namespace TrashBox.ViewModels
{
    public class ControlsViewModel : BaseViewModel
    {
        public enum ControlsPages
        {
            DonutChart,
            ProgressBar,
            RadialProgressBar
        }

        public ICommand GoToPageCommand { get; }

        public ControlsViewModel()
        {
            GoToPageCommand = new Command(async parameter => await GoToPageAsync(parameter));
        }

        private async Task GoToPageAsync(object parameter)
        {
            if (IsBusy || !(parameter is ControlsPages page))
            {
                return;
            }

            IsBusy = true;

            try
            {
                switch (page)
                {
                    case ControlsPages.DonutChart:
                    {
                        await ShellNavigationHelper.GoToAsync(nameof(DonutChartTabbedPage));

                        return;
                    }
                    case ControlsPages.ProgressBar:
                    {
                        await ShellNavigationHelper.GoToAsync(nameof(GradientProgressBarTabbedPage));

                        return;
                    }
                    case ControlsPages.RadialProgressBar:
                    {
                        await ShellNavigationHelper.GoToAsync(nameof(GradientRadialProgressBarTabbedPage));

                        return;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}