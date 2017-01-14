using BunnyEscape.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BunnyEscape.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Scores : Page
    {
        private IScoreViewModel Context;

        public Scores()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.Context = e.Parameter as IScoreViewModel;
            if (this.Context == null)
            {
                throw new ArgumentException("Invalid or missing Score context.");
            }
            this.DataContext = this.Context;
        }

        private void OnPageDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
