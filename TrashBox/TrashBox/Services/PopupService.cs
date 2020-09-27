using System;
using System.Threading.Tasks;
using TrashBox.Abstractions;
using TrashBox.Annotations;

namespace TrashBox.Services
{
    public class PopupService : IPopupService
    {
        #region Instance

        private static IPopupService _instance;

        public static IPopupService Instance => _instance ??= new PopupService();

        #endregion Instance

        public async Task ShowPopupAsync([NotNull] BasePopup popup)
        {
            if (popup == null)
            {
                throw new NullReferenceException();
            }

            await popup.ShowAsync();
        }

        public async Task HidePopupAsync([NotNull] BasePopup popup)
        {
            if (popup == null)
            {
                throw new NullReferenceException();
            }

            await popup.HideAsync();
        }
    }
}