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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shamsheer.Messenger.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for EmailLoginPage.xaml
    /// </summary>
    public partial class EmailLoginPage : Page
    {
        public EmailLoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CodeEntryPage());
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new QrCodePage());
        }

        private void qrCodeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new QrCodePage());
        }
    }
}
