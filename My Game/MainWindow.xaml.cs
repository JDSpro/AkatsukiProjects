using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace My_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            CloseCommand comm = new CloseCommand(this);
            var flyout = Flyouts.Items[0] as Flyout;
            flyout.IsOpen = true;
            flyout.CloseCommand = comm;

            LoginButton.Visibility = System.Windows.Visibility.Hidden;
            //DialogManager.ShowLoginAsync(this, "", "");
        }

        private void Flyout_ContextMenuClosing(object sender, RoutedEventArgs e)
        {
            LoginButton.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
