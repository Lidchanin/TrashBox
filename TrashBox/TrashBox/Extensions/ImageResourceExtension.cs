using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrashBox.Extensions
{
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider) =>
            Source == null
                ? null
                : ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
    }
}