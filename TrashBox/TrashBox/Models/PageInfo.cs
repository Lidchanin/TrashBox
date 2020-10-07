using System.ComponentModel;

namespace TrashBox.Models
{
    public sealed class PageInfo : INotifyPropertyChanged
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string IconResourceName { get; set; }

        public string Route { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}