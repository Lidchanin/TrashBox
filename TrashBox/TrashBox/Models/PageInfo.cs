using System.ComponentModel;
using TrashBox.Helpers;

namespace TrashBox.Models
{
    public sealed class PageInfo : INotifyPropertyChanged
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string IconResourceName { get; set; }

        public string Route { get; set; }

        public string TitleFontFamily { get; set; } = Constants.EmbeddedFonts.September22;

        public string DescriptionFontFamily { get; set; } = Constants.EmbeddedFonts.September22;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}