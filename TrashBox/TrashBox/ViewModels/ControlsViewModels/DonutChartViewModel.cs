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
        public ICommand SectorTouchCommand { get; }
        public ICommand HoleTouchCommand { get; }
        public ICommand AddExpenseCommand { get; }
        public ICommand RemoveExpenseCommand { get; }

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

        private readonly IList<(string Name, string Filename)> _possibleExpenses;

        public DonutChartViewModel()
        {
            SectorTouchCommand = new Command(ExpenseTouch);
            HoleTouchCommand = new Command(HoleTouch);
            AddExpenseCommand = new Command(AddExpense);
            RemoveExpenseCommand = new Command(RemoveExpense);

            _possibleExpenses = new List<(string Name, string Filename)>
            {
                ("Everyday Food", Constants.EmbeddedImages.Dish),
                ("Entertainment", Constants.EmbeddedImages.Entertainment),
                ("Fast Food", Constants.EmbeddedImages.FastFood),
                ("Medicine", Constants.EmbeddedImages.Pills),
                ("Repairing", Constants.EmbeddedImages.RepairTools),
                ("Transport", Constants.EmbeddedImages.Transport),
                ("Games", Constants.EmbeddedImages.VideoGame)
            };

            Expenses = new ObservableCollection<ExpenseChartItem>();
            Expenses.CollectionChanged += (sender, args) => { TotalValue = Expenses.Sum(x => x.Value); };

            AddExpense();
            AddExpense();
            AddExpense();
        }

        private static void ExpenseTouch(object parameter)
        {
            if (!(parameter is ExpenseChartItem item))
            {
                return;
            }

            Application.Current.MainPage.DisplayAlert("Info", $"\"{item.Name}\" was selected.\nValue = {item.Value}",
                "Ok");
        }

        private static void HoleTouch()
        {
            Application.Current.MainPage.DisplayAlert("Info", "Hole was touched.", "Ok");
        }

        private void AddExpense()
        {
            var random = new Random();

            var (name, filename) = _possibleExpenses[random.Next(_possibleExpenses.Count)];

            Expenses?.Add(new ExpenseChartItem
            {
                Value = random.Next(20, 100),
                SectionHexColor = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)).ToHex(),
                IconResourceName = filename,
                Name = name
            });
        }

        private void RemoveExpense()
        {
            if (Expenses?.Count > 0)
            {
                Expenses.Remove(Expenses[Expenses.Count - 1]);
            }
        }
    }
}