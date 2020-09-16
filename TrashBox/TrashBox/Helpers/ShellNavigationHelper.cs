using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashBox.Abstractions;
using Xamarin.Forms;

namespace TrashBox.Helpers
{
    public static class ShellNavigationHelper
    {
        public static BaseShell CurrentShell => (BaseShell) Shell.Current;

        public static Task GoToAsync(ShellNavigationState state, bool animate = true) =>
            CurrentShell.GoToAsync(state, animate);

        public static Task PopToRootAsync(bool animate = true) =>
            CurrentShell.CurrentItem.Navigation.PopToRootAsync(animate);

        public static Task PopAsync(bool animate = true) =>
            CurrentShell.GoToAsync("..", animate);

        public static Task SwitchTabAsync(string tabRoute, bool animate = true) =>
            CurrentShell.GoToAsync($"///{tabRoute}", animate);

        public static string GetCurrentShortRoute() =>
            CurrentShell?.CurrentState?.Location?.ToString()?.Split('/').LastOrDefault();

        public static string GetCurrentFullRoute() =>
            CurrentShell?.CurrentState?.Location?.ToString();

        public static string GetCurrentTabRoute() =>
            CurrentShell?.CurrentItem?.CurrentItem?.CurrentItem?.Route;

        public static IList<Page> GetPresentedPages()
        {
            if (!(CurrentShell?.CurrentItem?.Items is { } shellSections))
            {
                return null;
            }

            var pages = new List<Page>();

            foreach (var tab in shellSections)
            {
                if (tab is IShellSectionController controller && controller.PresentedPage is { } page)
                {
                    pages.Add(page);
                }
            }

            return pages;
        }
    }
}