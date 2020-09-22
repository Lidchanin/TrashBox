using System.ComponentModel;
using TrashBox.Services;

namespace TrashBox.Abstractions
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected static IThemeService ThemeService => ThemesService.Instance;

        protected bool IsBusy { get; set; }
    }
}