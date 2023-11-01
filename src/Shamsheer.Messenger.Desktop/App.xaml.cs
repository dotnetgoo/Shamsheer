using Shamsheer.Messenger.Desktop.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Shamsheer.Messenger.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.ShutdownMode = ShutdownMode.OnLastWindowClose;

            bool userSignin = true;

            if (userSignin)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                var userWindow = new Home();
                userWindow.Show();
            }
        }
    }
}
