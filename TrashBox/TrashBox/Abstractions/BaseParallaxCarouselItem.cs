using System.ComponentModel;

namespace TrashBox.Abstractions
{
    public abstract class BaseParallaxCarouselItem : INotifyPropertyChanged
    {
        public double Position { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}