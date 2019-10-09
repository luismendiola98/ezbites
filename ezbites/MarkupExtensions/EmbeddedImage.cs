using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ezbites.MarkupExtensions
{
    [ContentProperty("ResourceId")]
    public class EmbeddedImage : IMarkupExtension
    {
       
        public string ResourceId { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(ResourceId))
                return null;
            //else
            return ImageSource.FromResource(ResourceId);
        }
    }
}
