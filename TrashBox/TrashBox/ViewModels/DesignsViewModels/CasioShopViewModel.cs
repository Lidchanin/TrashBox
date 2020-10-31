using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TrashBox.Abstractions;
using TrashBox.Enums;
using TrashBox.Helpers;
using TrashBox.Models;
using Xamarin.Forms;

namespace TrashBox.ViewModels.DesignsViewModels
{
    public class CasioShopViewModel : BaseViewModel
    {
        public ICommand ClickSupportBarCommand { get; }
        public ICommand ClickFloatingButtonCommand { get; }

        public ObservableCollection<WatchInfo> Watches { get; } = new ObservableCollection<WatchInfo>();

        public WatchInfo CurrentWatch { get; set; }

        private IList<WatchInfo> _allWatches;

        public CasioShopViewModel()
        {
            ClickSupportBarCommand = new Command(async parameter => await ClickSupportBarAsync(parameter));
            ClickFloatingButtonCommand = new Command(async parameter => await ClickFloatingButtonAsync(parameter));
        }

        public void Init()
        {
            _allWatches = MockDataService.GetWatches();

            foreach (var watch in _allWatches.Where(w => w.Series == CasioWatchSeries.GShock))
            {
                Watches.Add(watch);
            }
        }

        private async Task ClickSupportBarAsync(object parameter)
        {
            if (!(parameter is CasioShopSupportBarButtons button))
            {
                return;
            }

            switch (button)
            {
                case CasioShopSupportBarButtons.Back:
                {
                    await ShellNavigationHelper.PopAsync();

                    return;
                }
                case CasioShopSupportBarButtons.MaleWatches:
                {
                    Watches.Clear();

                    foreach (var watch in _allWatches.Where(w => w.Series == CasioWatchSeries.GShock))
                    {
                        Watches.Add(watch);
                    }

                    CurrentWatch = Watches.FirstOrDefault();

                    return;
                }
                case CasioShopSupportBarButtons.FemaleWatches:
                {
                    Watches.Clear();

                    foreach (var watch in _allWatches.Where(w => w.Series == CasioWatchSeries.GShockWomen))
                    {
                        Watches.Add(watch);
                    }

                    CurrentWatch = Watches.FirstOrDefault();

                    return;
                }
                case CasioShopSupportBarButtons.BabyWatches:
                {
                    Watches.Clear();

                    foreach (var watch in _allWatches.Where(w => w.Series == CasioWatchSeries.BabyG))
                    {
                        Watches.Add(watch);
                    }

                    CurrentWatch = Watches.FirstOrDefault();

                    return;
                }
                case CasioShopSupportBarButtons.Discounts:
                {
                    Watches.Clear();

                    foreach (var watch in _allWatches.Where(w => w.DiscountPercent > 0)
                        .OrderByDescending(w => w.DiscountPercent))
                    {
                        Watches.Add(watch);
                    }

                    break;
                }
                case CasioShopSupportBarButtons.NewWatches:
                {
                    Watches.Clear();

                    foreach (var watch in _allWatches.Where(w => w.IsNew))
                    {
                        Watches.Add(watch);
                    }

                    break;
                }
                case CasioShopSupportBarButtons.ShoppingCart:
                {
                    Watches.Clear();

                    foreach (var watchInfo in _allWatches.Where(w => w.IsInCart))
                    {
                        Watches.Add(watchInfo);
                    }

                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async Task ClickFloatingButtonAsync(object parameter)
        {
            if (!(parameter is CasioShopFloatingButtons button))
            {
                return;
            }

            switch (button)
            {
                case CasioShopFloatingButtons.Notifications:
                    break;
                case CasioShopFloatingButtons.Bookmarks:
                    break;
                case CasioShopFloatingButtons.ShoppingCart:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}