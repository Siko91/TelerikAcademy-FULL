using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using System.Windows;
using Windows.UI.Xaml;

namespace BunnyEscape.Converters
{
    class ScreenPercentToHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return Convert((double)value);
            }
            catch (Exception e)
            {
                throw new ArgumentException("percent value is not compatable with the double type. Is it even a number?", e);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return ConvertBack((double)value);
            }
            catch (Exception e)
            {
                throw new ArgumentException("percent value is not compatable with the double type. Is it even a number?", e);
            }
        }
        public double Convert(double value)
        {
            double screenHeight = Window.Current.Bounds.Height;
            var result = screenHeight * value;
            return result;
        }

        public double ConvertBack(double value)
        {
            double screenHeight = Window.Current.Bounds.Height;
            var result = value / screenHeight;
            return result;
        }
    }
}
