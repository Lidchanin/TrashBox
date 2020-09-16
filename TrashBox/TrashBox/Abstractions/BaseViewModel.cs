using System.ComponentModel;

namespace TrashBox.Abstractions
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool IsBusy { get; set; }
    }
}