using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MongoDbChat.WpfClient
{
    /// <summary>
    /// Interaction logic for InputUsernameWindow.xaml
    /// </summary>
    public partial class InputUsernameWindow : Window
    {
        public InputUsernameWindow()
        {
            InitializeComponent();
        }


        public string Username
        {
            get 
            {
                return UsernameTextBox.Text; 
            }
            set 
            {
                UsernameTextBox.Text = value;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            //this.Close();
        }
    }
}
