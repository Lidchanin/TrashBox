using System.ComponentModel;
using TrashBox.Services;

namespace TrashBox.Abstractions
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected static IPopupService PopupService => Services.PopupService.Instance;

        protected static IThemeService ThemesService => Services.ThemesService.Instance;

        protected static IMockDataService MockDataService => Services.MockDataService.Instance;

        protected bool IsBusy { get; set; }
    }
}