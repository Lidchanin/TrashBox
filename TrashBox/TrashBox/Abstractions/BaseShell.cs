using Xamarin.Forms;

namespace TrashBox.Abstractions
{
    public abstract class BaseShell : Shell
    {
        public abstract void RegisterRoutes();

        public abstract void UnRegisterRoutes();
    }
}