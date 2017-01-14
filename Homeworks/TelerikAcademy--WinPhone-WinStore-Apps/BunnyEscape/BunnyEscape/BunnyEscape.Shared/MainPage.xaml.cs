using BunnyEscape;
using BunnyEscape.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WinRTXamlToolkit.Debugging;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BunnyEscape
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private LoadingScreenViewModel Context;
        public MainPage()
        {
            this.InitializeComponent();
            this.Context = new LoadingScreenViewModel();
            this.DataContext = this.Context;

            //DC.ShowVisualTree();
        }

        private void OnAnywhereLongPress(object sender, HoldingRoutedEventArgs e)
        {
            this.Context.GoToMainMenu(this.Frame);
        }

        private void OnAnywhereDoubleTap(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Context.GoToMainMenu(this.Frame);
        }
    }
}