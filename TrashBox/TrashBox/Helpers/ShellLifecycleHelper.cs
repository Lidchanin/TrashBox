using TrashBox.Abstractions;
using Xamarin.Forms;

namespace TrashBox.Helpers
{
    public static class ShellLifecycleHelper
    {
        public static TShell CreateShell<TShell>() where TShell : BaseShell, new()
        {
            var shell = new TShell();

            shell.RegisterRoutes();

            return shell;
        }

        public static void DestroyShell<TShell>(TShell shell) where TShell : Shell
        {
            if (!(shell is BaseShell baseShell))
            {
                return;
            }

            baseShell.UnRegisterRoutes();
        }
    }
}