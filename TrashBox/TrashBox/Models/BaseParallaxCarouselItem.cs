using System.ComponentModel;

namespace TrashBox.Models
{
    public abstract class BaseParallaxCarouselItem : INotifyPropertyChanged
    {
        public double ParallaxTranslation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}