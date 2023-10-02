using Shamsheer.Messenger.Desktop.Components;
using Shamsheer.Messenger.Desktop.Models;
using Shamsheer.Messenger.Desktop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        List<User> GLOBAL_USERS = new List<User>();
        private void drag_grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

        private void OpenMenu_Btn_Click(object sender, RoutedEventArgs e)
        {
            var boshlash = new Thickness(-280, 0, 0, 0);
            var tugatish = new Thickness(0, 0, 0, 0);
            var da = new ThicknessAnimation();
            da.From = boshlash;
            da.To = tugatish;
            da.Duration = TimeSpan.FromMilliseconds(200);
            MenuGrid.BeginAnimation(MarginProperty, da);
            CloseMenu_Border.Visibility = Visibility.Visible;
        }

        private void CloseMenu_Border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CloseMenu_Border.Visibility = Visibility.Collapsed;
            menuClose();
        }

        private void newGroup_Btn_Click(object sender, RoutedEventArgs e)
        {
            menuClose();
            Window_Loaded(sender, null);
        }

        private void settings_Btn_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new Settings();
            menuClose();
        }

        
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<User> GLOBAL_USERS = new List<User>();
            GLOBAL_USERS.Add(new User()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doel",
                FriendName = "Michael",
                FriendMessage = "Hello bro?",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            });
            Thread thread = new Thread(() =>
            {
                this.Dispatcher.Invoke(async () =>
                {
                    //users loading
                    usersPanel.Items.Clear();

                    foreach (var user in GLOBAL_USERS)
                    {
                        await Task.Run(() =>
                        {
                            this.Dispatcher.Invoke(() =>
                            {
                                var privateChat = new PrivateChat();
                                privateChat.username.Text = user.FirstName + " " + user.LastName;
                                privateChat.friend_name.Text = user.FriendName;
                                privateChat.friend_message.Text = user.FriendMessage;
                                privateChat.updated_at.Text = user.UpdatedAt.ToString();
                                usersPanel.Items.Add(privateChat);
                            });

                        });
                    }
                });
            });
            thread.Start();

        }

        public void menuClose()
        {
            //
            var boshlash = new Thickness(0, 0, 0, 0);
            var tugatish = new Thickness(-280, 0, 0, 0);
            var da = new ThicknessAnimation();
            da.From = boshlash;
            da.To = tugatish;
            da.Duration = TimeSpan.FromMilliseconds(200);
            MenuGrid.BeginAnimation(MarginProperty, da);
            //
            CloseMenu_Border.Visibility = Visibility.Collapsed;
        }

        private async void searchTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = searchTxt.Text.ToLower();


            //foreach (var user in all)
            //{
            //    await Task.Run(() =>
            //    {
            //        this.Dispatcher.Invoke(() =>
            //        {
            //            var pri = new Private();
            //            pri.username.Text = user.firstname + " " + user.lastname;
            //            pri.friend_name.Text = user.friend_name;
            //            pri.friend_message.Text = user.friend_message;
            //            pri.updated_at.Text = user.updated_at.ToString();
            //            usersPanel.Items.Add(pri);
            //        });
            //    });
            //}
        }

    }




}
