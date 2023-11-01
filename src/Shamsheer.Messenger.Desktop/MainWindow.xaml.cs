using Shamsheer.Messenger.Desktop.Pages;
using System;
using System.Windows;
using System.Windows.Input;

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
        private void NavBar(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                maximize_btn_Click(sender, null);
            }
            else
            {
                this.DragMove();
            }
        }

        private void minimize_btn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void maximize_btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                windowGrid.Margin = new Thickness(8, 10, 10, 10);
                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                windowGrid.Margin = new Thickness(0);
            }
        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void startMessagingBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new QrCodePage());
        }
    }
}
