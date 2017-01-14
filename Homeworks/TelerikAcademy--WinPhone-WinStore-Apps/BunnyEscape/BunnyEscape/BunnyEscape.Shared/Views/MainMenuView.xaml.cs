using BunnyEscape.Handlers;
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

namespace BunnyEscape.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenuView : Page
    {
        private MenuViewModel Context;
        public MainMenuView()
        {
            this.InitializeComponent();
            //new BackgroundTaskHandler().StartTask(BackgroundTaskHandler.MusicTaskName, BackgroundTaskHandler.MusicTaskEntryPoint);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if ((e.Parameter != null) || (e.Parameter is MenuViewModel))
            {
                this.Context = e.Parameter as MenuViewModel;
                this.DataContext = this.Context;
                return;
            }

            this.Context = new MenuViewModel();
            this.DataContext = this.Context;
        }

        private void OnPlayBtnClick(object sender, RoutedEventArgs e)
        {
            bool turboModeIsOn = turboModeCheckBox.IsChecked.Value;
            this.Frame.Navigate(typeof(Game), turboModeIsOn);
        }

        private void OnStoryBtnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StoryView));
        }


        private void OnLocalScoresBtnClick(object sender, RoutedEventArgs e)
        {
            var scoreHandler = new LocalRankingViewModel();
            this.Frame.Navigate(typeof(Scores), scoreHandler);
        }

        private void OnInternetScoresBtnClick(object sender, RoutedEventArgs e)
        {
            var scoreHandler = new InternetRankingViewModel();
            this.Frame.Navigate(typeof(Scores), scoreHandler);
        }

        private void OnToturialBtnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HowToPlayView));
        }

    }
}
