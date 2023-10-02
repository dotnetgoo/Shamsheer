using MaterialDesignThemes.Wpf;
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

namespace Shamsheer.Messenger.Desktop.Components
{
    /// <summary>
    /// Interaction logic for MenuButton.xaml
    /// </summary>
    public partial class MenuButton : UserControl
    {
        public MenuButton()
        {
            InitializeComponent();
        }
        public string Text { get; set; }
        public string Icon { get; set; }
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            iconMenu.Foreground = Brushes.White;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            var ob = (Color)ColorConverter.ConvertFromString("#6C7883");
            iconMenu.Foreground = new SolidColorBrush(ob);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            textMenu.Text = Text;
            textMenu.FontWeight = this.FontWeight;
            iconMenu.Kind = (PackIconKind)Enum.Parse(typeof(PackIconKind), Icon);
        }
    }
}
