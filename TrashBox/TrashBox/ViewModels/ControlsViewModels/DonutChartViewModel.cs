using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TrashBox.Abstractions;
using TrashBox.Controls.DonutChart;
using TrashBox.Helpers;
using Xamarin.Forms;

namespace TrashBox.ViewModels.ControlsViewModels
{
    public class DonutChartViewModel : BaseViewModel
    {
        public ObservableCollection<DonutChartItem> ChartItems { get; }
        public float TotalValue { get; private set; }

        public float HoleRadius { get; set; } = 0.5f;
        public float LineToCircleLength { get; set; } = 20f;
        public float DescriptionCircleRadius { get; set; } = 20f;
        public float SeparatorsWidth { get; set; } = 2f;
        public float InnerMargin { get; set; } = 100f;

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
            Color.DarkViolet
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
            ChartItems = new ObservableCollection<DonutChartItem>();
            ChartItems.CollectionChanged += (sender, args) => { TotalValue = ChartItems.Sum(x => x.Value); };
            ChartItems.Add(new DonutChartItem
            {
                Value = 55,
                SectionHexColor = Color.DarkRed.ToHex(),
                ImagePath = Constants.Filenames.AboutUs
            });
            ChartItems.Add(new DonutChartItem
            {
                Value = 45,
                SectionHexColor = Color.White.ToHex(),
                ImagePath = Constants.Filenames.BrokenFile
            });
            ChartItems.Add(new DonutChartItem
            {
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
            if (!(parameter is DonutChartItem item))
            {
                return;
            }

            Application.Current.MainPage.DisplayAlert("Info", $"Sector was touched.\nValue = {item.Value}", "Ok");
        }

        private static void HoleTouch()
        {
            Application.Current.MainPage.DisplayAlert("Info", "Hole was touched.", "Ok");
        }

        private void AddSector()
        {
            var random = new Random();
            var value = random.Next(30, 80);
            var color = _chartColors[random.Next(_chartColors.Count)];
            var imagePath = _chartImages[random.Next(_chartImages.Count)];

            ChartItems?.Add(new DonutChartItem
            {
                Value = value,
                SectionHexColor = color.ToHex(),
                ImagePath = imagePath
            });
        }

        private void RemoveSector()
        {
            if (ChartItems?.Count > 0)
            {
                ChartItems.Remove(ChartItems[ChartItems.Count - 1]);
            }
        }
    }
}