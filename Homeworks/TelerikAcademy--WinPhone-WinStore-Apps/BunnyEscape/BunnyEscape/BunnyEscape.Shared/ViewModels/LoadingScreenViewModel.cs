using BunnyEscape.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace BunnyEscape.ViewModels
{
    public class LoadingScreenViewModel
    {
        internal void GoToMainMenu(Frame frame)
        {
            frame.Navigate(typeof(MainMenuView), new MenuViewModel());
        }

        public string BackgroundImagePath 
        {
            get { return @"Resourses\Real\background.gif"; }
        }
        public double TextTopPositionPercent { get { return 0.25; } }
    }
}
