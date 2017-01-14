using BunnyEscape.Core;
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
    public sealed partial class StoryView : Page
    {
        public StoryView()
        {
            this.InitializeComponent();
            this.DataContext = new StoryViewModel();
            (this.DataContext as StoryViewModel).PropertyChanged += OnStoryViewModelPropertyChanged;
            this.responcesPanel.Opacity = 0;
        }

        private void OnStoryViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var propName = e.PropertyName;
            if (propName == "CurrentDialogueOptions")
            {
                var vm = sender as StoryViewModel;
                if (vm.CurrentDialogueOptions.Count() > 0)
                {
                    this.responcesPanel.Opacity = 1;

                    var text1 = new TextBlock();
                    text1.Text = vm.CurrentDialogueOptions.ToArray()[0];
                    responce1.Content = text1;

                    var text2 = new TextBlock();
                    text2.Text = vm.CurrentDialogueOptions.ToArray()[1];
                    responce2.Content = text2;

                    var text3 = new TextBlock();
                    text3.Text = vm.CurrentDialogueOptions.ToArray()[2];
                    responce3.Content = text3;
                }
                else
                {
                    this.responcesPanel.Opacity = 0;
                }
            }
        }

        private void OnPageTapped(object sender, TappedRoutedEventArgs e)
        {
            (this.DataContext as StoryViewModel).OnActionWithoutResponseChoice();
            CheckIfFinished();
        }

        private void OnResponseButtonClick(object sender, RoutedEventArgs e)
        {
            (this.DataContext as StoryViewModel).OnActionWithResponseChoice();
            CheckIfFinished();
        }

        private void CheckIfFinished()
        {
            if ((this.DataContext as StoryViewModel).DialogueFinished)
            {
                this.Frame.GoBack();
            }
        }
    }
}
