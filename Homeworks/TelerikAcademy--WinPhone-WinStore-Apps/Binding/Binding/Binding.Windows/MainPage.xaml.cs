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

namespace Binding
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        IEnumerable<Color> colors;

        public MainPage()
        {
            this.InitializeComponent();
            this.colors = Color.GetPresetColors();

            backgrComboBox.ItemsSource = colors;
            backgrComboBox.DisplayMemberPath = "name";
            backgrComboBox.SelectedValue = 0;

            forgrComboBox.ItemsSource = colors;
            forgrComboBox.DisplayMemberPath = "name";
            forgrComboBox.SelectedValue = 0;
        }

        private void OnFontPresetBtnClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn != null) 
            {
                switch (btn.Name)
                {
                    case "btnTo24": sl.Value = 24; break;
                    case "btnTo46": sl.Value = 46; break;
                    case "btnTo82": sl.Value = 82; break;
                    default:
                        break;
                }
            }
        }

        private void forgrComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var color = forgrComboBox.SelectedValue as Color;
            task3Grid.Background = new SolidColorBrush(color.value);
        }

        private void backgrComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var color = backgrComboBox.SelectedValue as Color;
            task3Text.Foreground = new SolidColorBrush(color.value);
        }
    }
}
