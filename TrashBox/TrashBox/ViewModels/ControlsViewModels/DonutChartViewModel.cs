using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TrashBox.Abstractions;
using TrashBox.Helpers;
using TrashBox.Models;
using Xamarin.Forms;

namespace TrashBox.ViewModels.ControlsViewModels
{
    public class DonutChartViewModel : BaseViewModel
    {
        public ObservableCollection<ExpenseChartItem> Expenses { get; }
        public float TotalValue { get; private set; }

        public float HoleRadius { get; set; } = 0.5f;
        public float LineToCircleLength { get; set; } = 20f;
        public float DescriptionCircleRadius { get; set; } = 20f;
        public float SeparatorsWidth { get; set; } = 2f;
        public float InnerMargin { get; set; } = 100f;
        public float HolePrimaryTextScale { get; set; } = 1;
        public float HoleSecondaryTextScale { get; set; } = 1;
        public string HolePrimaryText { get; set; } = "Total";

        public ICommand SectorTouchCommand { get; }
        public ICommand HoleTouchCommand { get; }
        public ICommand AddSectorCommand { get; }
        public ICommand RemoveSectorCommand { get; }

        private readonly IList<Color> _chartColors = new List<Color>
        {
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.SkyBlue,
            Color.Blue,
            Color.DarkViolet,
            Color.Gold,
            Color.Chocolate,
            Color.Blue,
            Color.Violet
        };

        private readonly IList<string> _chartImages = new List<string>
        {
            Constants.Filenames.Car,
            Constants.Filenames.Cocktail,
            Constants.Filenames.Meal,
            Constants.Filenames.Plane,
            Constants.Filenames.Shirt
        };

        public DonutChartViewModel()
        {
            Expenses = new ObservableCollection<ExpenseChartItem>();
            Expenses.CollectionChanged += (sender, args) => { TotalValue = Expenses.Sum(x => x.Value); };

            Expenses.Add(new ExpenseChartItem
            {
                Name = Constants.Filenames.AboutUs.Split('.').FirstOrDefault(),
                Value = 55,
                SectionHexColor = Color.DarkRed.ToHex(),
                ImagePath = Constants.Filenames.AboutUs
            });
            Expenses.Add(new ExpenseChartItem
            {
                Name = Constants.Filenames.BrokenFile.Split('.').FirstOrDefault(),
                Value = 45,
                SectionHexColor = Color.White.ToHex(),
                ImagePath = Constants.Filenames.BrokenFile
            });
            Expenses.Add(new ExpenseChartItem
            {
                Name = "Without Image",
                Value = 50,
                SectionHexColor = Color.DarkGreen.ToHex()
            });

            SectorTouchCommand = new Command(SectorTouch);
            HoleTouchCommand = new Command(HoleTouch);
            AddSectorCommand = new Command(AddSector);
            RemoveSectorCommand = new Command(RemoveSector);
        }

        private static void SectorTouch(object parameter)
        {
            if (!(parameter is ExpenseChartItem item))
            {
                return;
            }

            Application.Current.MainPage.DisplayAlert("Info",
                $"Sector \"{item.Name}\" was touched.\nValue = {item.Value}", "Ok");
        }

        private static void HoleTouch()
        {
            Application.Current.MainPage.DisplayAlert("Info", "Hole was touched.", "Ok");
        }

        private void AddSector()
        {
            var random = new Random();

            var image = _chartImages[random.Next(_chartImages.Count)];

            var expense = new ExpenseChartItem
            {
                Value = random.Next(30, 80),
                SectionHexColor = _chartColors[random.Next(_chartColors.Count)].ToHex(),
                ImagePath = image,
                Name = image.Split('.').FirstOrDefault()
            };

            Expenses?.Add(expense);
        }

        private void RemoveSector()
        {
            if (Expenses?.Count > 0)
            {
                Expenses.Remove(Expenses[Expenses.Count - 1]);
            }
        }
    }
}