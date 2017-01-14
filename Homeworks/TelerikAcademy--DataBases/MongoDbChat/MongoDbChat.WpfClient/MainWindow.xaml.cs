using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MongoDbChat.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            while (true)
            {
                InputUsernameWindow askForUsernameWindow = new InputUsernameWindow();
                askForUsernameWindow.ShowDialog();
                if (askForUsernameWindow.DialogResult == true)
                {
                    this.username = askForUsernameWindow.Username;
                    if (this.username.Length == 0)
                    {
                        MessageBox.Show("You must input a username");
                        continue;
                    }
                    else
                    {
                        MessageBox.Show("Logging in...");
                        break;
                    }
                }
            }
            InitializeComponent();
            this.connector = new MongoConnector();
            this.RefreshMessages(null, null);
        }

        private MongoConnector connector;
        private string username;

        private void RefreshMessages(object sender, RoutedEventArgs e)
        {
            this.MessageListView.Items.Clear();
            ICollection<Message> messages = this.connector.GetMessages();
            foreach (Message msg in messages)
            {
                this.MessageListView.Items.Add(new
                {
                    user = msg.user,
                    date = msg.date,
                    text = msg.text
                });
            }
        }

        private void SendNewMessage(object sender, RoutedEventArgs e)
        {
            string text = this.MessageTextBox.Text;
            if (text.Length > 0)
            {
                Message msg = new Message(this.username, text);
                this.connector.AddMessage(msg);
                this.MessageTextBox.Text = "";
                this.RefreshMessages(null, null);
            }
        }
    }
}