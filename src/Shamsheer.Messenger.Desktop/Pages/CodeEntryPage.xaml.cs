using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Shamsheer.Messenger.Desktop.Pages
{
    public partial class CodeEntryPage : Page
    {
        private DispatcherTimer timer; // Timer obyekti saqlash uchun

        public CodeEntryPage()
        {
            InitializeComponent();
            StartCountdown();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EmailLoginPage());
        }

        private void SendCodeAgain_Click(object sender, RoutedEventArgs e)
        {
            StartCountdown();
            sendCodeAgainBtn.IsEnabled = false; // Tugmani nofaol qilamiz
        }

        private void StartCountdown()
        {
            int countdownDurationInSeconds = 59;
            var countdown = TimeSpan.FromSeconds(countdownDurationInSeconds);

            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }

            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                CountdownText.Text = countdown.ToString(@"mm\:ss");

                if (countdown == TimeSpan.Zero)
                {
                    timer.Stop(); // Vaqt tugaganidan so'ng timer to'xtatiladi
                    sendCodeAgainBtn.IsEnabled = true; // Tugmani qayta faol qilamiz
                }

                countdown = countdown.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            timer.Start();
        }

        private void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RegistrPage());
        }
    }
}
