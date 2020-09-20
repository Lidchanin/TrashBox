﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TrashBox.Abstractions;
using TrashBox.Helpers;
using TrashBox.Views.DesignsPages;
using Xamarin.Forms;

namespace TrashBox.ViewModels.DesignsViewModels
{
    public class DesignsViewModel : BaseViewModel
    {
        public enum DesignsPages
        {
            HorizontalParallaxCarousel
        }

        public ICommand GoToPageCommand { get; }

        public DesignsViewModel()
        {
            GoToPageCommand = new Command(async parameter => await GoToPageAsync(parameter));
        }

        private async Task GoToPageAsync(object parameter)
        {
            if (IsBusy || !(parameter is DesignsPages page))
            {
                return;
            }

            IsBusy = true;

            try
            {
                switch (page)
                {
                    case DesignsPages.HorizontalParallaxCarousel:
                    {
                        await ShellNavigationHelper.GoToAsync(nameof(HorizontalParallaxCarouselPage));

                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}