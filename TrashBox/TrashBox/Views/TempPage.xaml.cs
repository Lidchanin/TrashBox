using System;
using System.Collections.Generic;
using TrashBox.Enums;
using TrashBox.Helpers;
using TrashBox.Models;

namespace TrashBox.Views
{
    public partial class TempPage
    {
        public IList<CasioShopSupportBarItem> HorizontalShopSupportBarItems { get; } =
            new List<CasioShopSupportBarItem>()
            {
                new CasioShopSupportBarItem {Text = Constants.FontAwesomeIcons.Heart, Option = CasioShopSupportBarOptions.NewWatches},
                new CasioShopSupportBarItem {Text = Constants.FontAwesomeIcons.Child, Option = CasioShopSupportBarOptions.BabyWatches},
                new CasioShopSupportBarItem {Text = Constants.FontAwesomeIcons.Female, Option = CasioShopSupportBarOptions.FemaleWatches},
                new CasioShopSupportBarItem {Text = Constants.FontAwesomeIcons.Bookmark, Option = CasioShopSupportBarOptions.Discounts},
            };

        public CasioShopSupportBarItem SelectedItem { get; set; }

        public IList<CasioShopSupportBarItem> VerticalShopSupportBarItems { get; set; } =
            new List<CasioShopSupportBarItem>();

        public TempPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            SelectedItem = null;
        }

        private void Button2_OnClicked(object sender, EventArgs e)
        {
            SelectedItem = HorizontalShopSupportBarItems[0];
        }
    }
}