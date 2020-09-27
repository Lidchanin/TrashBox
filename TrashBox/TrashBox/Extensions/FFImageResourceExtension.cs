using System;
using Xamarin.Forms.Xaml;

namespace TrashBox.Extensions
{
    public class FFImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider) =>
            Source == null
                ? null
                : $"resource://{Source}";
    }
}