using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml.Media.Animation;

namespace BunnyEscape.CustomViews.Gif
{
    public sealed partial class GifImage : UserControl
    {
        private static readonly DependencyProperty _imageUrlProperty = DependencyProperty.Register
        (
            "ImageUrl", typeof(string), typeof(GifImage), new PropertyMetadata(String.Empty, ImageUrlPropertyChanged)
        );

        private double HtmlWidth
        {
            get;
            set;
        }

        private double HtmlHeight
        {
            get;
            set;
        }

        private string Html
        {
            get
            {
                return String.Format("<html><body style=\"background: url('ms-appx-web://{0}') no-repeat scroll;background-size: {1} {2};\"/></html>", ImageUrl, MakeSize(HtmlWidth), MakeSize(HtmlHeight));
            }
        }
        public string ImageUrl
        {
            get
            {
                return (string)GetValue(_imageUrlProperty);
            }
            set
            {
                SetValue(_imageUrlProperty, value);
            }
        }
        public GifImage()
        {
            this.InitializeComponent();
        }
        private string MakeSize(double val)
        {
            return String.Format("{0}px", (int)val);
        }

        private void WebSizeChanged(object sender, SizeChangedEventArgs e)
        {
            HtmlWidth = e.NewSize.Width;
            HtmlHeight = e.NewSize.Height;

            RefreshWebView();
        }

        private void RefreshWebView()
        {
            web.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            web.NavigateToString(Html);
        }

        private static void ImageUrlPropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            var control = (GifImage)sender;

            control.ImageUrl = (string)args.NewValue;
            control.RefreshWebView();
        }

        private void web_LoadCompleted(object sender, NavigationEventArgs e)
        {
            web.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
    }
}