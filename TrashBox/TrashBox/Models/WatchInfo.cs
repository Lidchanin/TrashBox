using System.Collections.Generic;
using System.ComponentModel;
using TrashBox.Enums;

namespace TrashBox.Models
{
    public sealed class WatchInfo : INotifyPropertyChanged
    {
        public CasioWatchSeries Series { get; set; }

        public string ImagePath { get; set; }

        public string Name { get; set; }

        public IList<string> MainAdvantages { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// DiscountPercent from 0 to 100
        /// </summary>
        public int DiscountPercent { get; set; }

        public double Cost { get; set; }

        public double CostWithDiscount => DiscountPercent > 0 ? Cost - (Cost * DiscountPercent / 100) : Cost;

        public bool IsNew { get; set; }

        public bool IsInCart { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}