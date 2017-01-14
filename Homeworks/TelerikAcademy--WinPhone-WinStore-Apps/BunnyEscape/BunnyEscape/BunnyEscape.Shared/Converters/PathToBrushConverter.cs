using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace BunnyEscape.Converters
{
    public class PathToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string path = "ms-appx:/" + value.ToString();
            ImageBrush br = new ImageBrush();
            br.ImageSource = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
            br.Stretch = Stretch.Fill;

            return br;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return "ConvertBack is not supported from PathToBrushConverter";
        }
    }
}
