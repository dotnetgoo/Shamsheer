using Shamsheer.Messenger.Desktop.Pages;
using System;
using System.Windows;

namespace Shamsheer.Messenger.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startMessagingBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new QrCodePage());
        }
    }
}
