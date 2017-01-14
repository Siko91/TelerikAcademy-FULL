using BunnyEscape.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class GameOverView : Page
    {
        private GameOverViewModel Context;
        public GameOverView()
        {
            this.InitializeComponent();
            this.Context = new GameOverViewModel();
            this.DataContext = this.Context;
        }

        private void OnReadyBtnClick(object sender, RoutedEventArgs e)
        {
            if (!this.Context.IsReadyToContinue)
            {
                nickNameInput.Background = new SolidColorBrush(Color.FromArgb(255,255,0,0));
                nickNameInput.Focus(FocusState.Pointer);
                return;
            }

            this.Context.MakeNotification();

            bool localSave = localScoreSaveCheckbox.IsChecked.HasValue && localScoreSaveCheckbox.IsChecked.Value;
            bool globalSave = globalScoreSaveCheckbox.IsChecked.HasValue && globalScoreSaveCheckbox.IsChecked.Value;

            if (localSave)
            {
                this.Context.SaveScoreLocaly();
            }
            if (globalSave)
            {
                this.Context.SaveScoreGlobaly();
            }
            this.Frame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try
            {
                long score =(long)e.Parameter;
                this.Context.Score = score;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
