using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrashBox.Helpers
{
    public static class DeviceHelper
    {
        public static Task<T> BeginInvokeOnMainThreadAsync<T>(Func<Task<T>> func)
        {
            var tcs = new TaskCompletionSource<T>();

            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    var result = await func();

                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });

            return tcs.Task;
        }
    }
}