using Rg.Plugins.Popup.Contracts;
using System;
using System.Threading.Tasks;
using TrashBox.Helpers;

namespace TrashBox.Abstractions
{
    public partial class BasePopup
    {
        protected static IPopupNavigation PopupNavigation => Rg.Plugins.Popup.Services.PopupNavigation.Instance;

        public BasePopup()
        {
            InitializeComponent();
        }

        public virtual async Task ShowAsync()
        {
            try
            {
                await DeviceHelper.BeginInvokeOnMainThreadAsync(async () =>
                {
                    await PopupNavigation.PushAsync(this);

                    return true;
                });
            }
            catch (Exception exception)
            {
                // TODO ignored exception
            }
        }

        public virtual async Task HideAsync()
        {
            try
            {
                await DeviceHelper.BeginInvokeOnMainThreadAsync(async () =>
                {
                    await PopupNavigation.RemovePageAsync(this);

                    return true;
                });
            }
            catch (Exception exception)
            {
                // TODO ignored exception

                await DeviceHelper.BeginInvokeOnMainThreadAsync(async () =>
                {
                    await PopupNavigation.PopAsync();

                    return true;
                });
            }
        }
    }
}