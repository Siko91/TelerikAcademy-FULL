using BunnyEscape.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace BunnyEscape.CustomViews
{
    class BunnyEscapeCanvas : ItemsControl
    {
        static PathToBrushConverter imageConverter;
        static ScreenPercentToHeightConverter heightConverter;
        static ScreenPercentToWidthConverter widthConverter;

        public BunnyEscapeCanvas()
        {
            if (heightConverter == null)
            {
                heightConverter = new ScreenPercentToHeightConverter();
            }
            if (widthConverter == null)
            {
                widthConverter = new ScreenPercentToWidthConverter();
            }
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var control = element as FrameworkElement;
            if (control == null)
            {
                return;
            }

            var topBinding = new Binding()
            {
                Path = new PropertyPath("PositionTopPercentage"),
                Converter = heightConverter
            };
            control.SetBinding(Canvas.TopProperty, topBinding);

            var leftBinding = new Binding()
            {
                Path = new PropertyPath("PositionLeftPercentage"),
                Converter = widthConverter
            };
            control.SetBinding(Canvas.LeftProperty, leftBinding);

            base.PrepareContainerForItemOverride(element, item);
        }
    }
}
