using System.Collections.ObjectModel;
using TrashBox.Abstractions;
using TrashBox.Helpers;
using TrashBox.Models;

namespace TrashBox.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ObservableCollection<AboutItem> AboutItems { get; }

        public AboutViewModel()
        {
            AboutItems = new ObservableCollection<AboutItem>
            {
                new AboutItem {Filename = Constants.Filenames.AboutUs, Link = Constants.Links.AboutUsIcon},
                new AboutItem {Filename = Constants.Filenames.AppIcon, Link = Constants.Links.AppIcon},
                new AboutItem {Filename = Constants.Filenames.BrokenFile, Link = Constants.Links.BrokenFileIcon},
                new AboutItem {Filename = Constants.Filenames.Car, Link = Constants.Links.CarIcon},
                new AboutItem {Filename = Constants.Filenames.Cocktail, Link = Constants.Links.CocktailIcon},
                new AboutItem {Filename = Constants.Filenames.DonutChart, Link = Constants.Links.DonutChartIcon},
                new AboutItem {Filename = Constants.Filenames.Meal, Link = Constants.Links.MealIcon},
                new AboutItem {Filename = Constants.Filenames.NoBorder, Link = Constants.Links.NoBorderIcon},
                new AboutItem {Filename = Constants.Filenames.Plane, Link = Constants.Links.PlaneIcon},
                new AboutItem {Filename = Constants.Filenames.ProgressBar, Link = Constants.Links.ProgressBarIcon},
                new AboutItem
                    {Filename = Constants.Filenames.VerticalProgressBar, Link = Constants.Links.ProgressBarIcon},
                new AboutItem
                    {Filename = Constants.Filenames.RadialProgressBar, Link = Constants.Links.RadialProgressBarIcon},
                new AboutItem {Filename = Constants.Filenames.Shirt, Link = Constants.Links.ShirtIcon}
            };
        }
    }
}