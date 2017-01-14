using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace BunnyEscape.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                bool visible = (bool)value;
                if (visible)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Windows.UI.Xaml.Visibility.Collapsed;
                }
            }
            catch (InvalidCastException e)
            {
                throw new ArgumentException("value must be bool", e);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                Visibility visibility = (Visibility)value;
                if (visibility == Visibility.Collapsed)
                {
                    return false;
                }
                return true;
            }
            catch (InvalidCastException e)
            {
                throw new ArgumentException("value must be Visibility", e);
            }
        }
    }
}
