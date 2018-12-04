using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
            
            //SignInTabItemHeaderButton.MouseDown += SignInTabItemHeaderButton_MouseDown;
            //SignUpTabItemHeaderButton.MouseDown += SignUpTabItemHeaderButton_MouseDown;

            //SignInLabel.MouseEnter += SignInLabel_MouseEnter;
            //SignUpLabel.MouseEnter += SignUpLabel_MouseEnter;
            //SignInLabel.MouseLeave += SignInLabel_MouseLeave;
            //SignUpLabel.MouseLeave += SignUpLabel_MouseLeave;

            //EnterButton.MouseEnter += EnterButton_MouseEnter;

            SignUpPicture.MouseDown += SignUpPicture_MouseDown;

            EnterButton.MouseDown += EnterButton_MouseDown;
            RegButton.MouseDown += RegButton_MouseDown;

            FlayoutTabCotrol.SelectionChanged += FlayoutTabCotrol_SelectionChanged;
        }

        private void RegButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Utilities.Registration("sd","sd","sd");
        }

        private void EnterButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void SignUpPicture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    SignUpPicture.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                }
                catch (System.NotSupportedException)
                {
                    MessageBox.Show("Невернный формат изображения." , "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void EnterButton_MouseEnter(object sender, MouseEventArgs e)
        {
            //EnterButton.Background = new SolidColorBrush(Colors.Black);
            EnterButton.Foreground = new SolidColorBrush(Colors.White);
        }

        private void FlayoutTabCotrol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FlayoutTabCotrol.SelectedIndex == 0)
            {
                SignInTabItem.Background = new SolidColorBrush(Colors.White);
                SignUpTabItem.Background = (System.Windows.Media.Brush)new BrushConverter().ConvertFrom("#41B1E1");
                SignInUpFlayout.Header = "Вход";

            }
            else if (FlayoutTabCotrol.SelectedIndex == 1)
            {
                SignUpTabItem.Background = new SolidColorBrush(Colors.White);
                SignInTabItem.Background = (System.Windows.Media.Brush)new BrushConverter().ConvertFrom("#41B1E1");
                SignInUpFlayout.Header = "Регистрация";
            }
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

        //private void SignUpTabItemHeaderButton_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    SignUpTabItemHeaderButton.Background = new SolidColorBrush(Colors.White);
        //    SignInTabItemHeaderButton.Background = (System.Windows.Media.Brush)new BrushConverter().ConvertFrom("#41B1E1");
        //}

        //private void SignInTabItemHeaderButton_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    Button btn = sender as Button;

        //    SignInTabItemHeaderButton.Background = new SolidColorBrush(Colors.White);
        //    btn.Background = (System.Windows.Media.Brush)new BrushConverter().ConvertFrom("#41B1E1");
        //}

        #region TabLabelMouseActions
        //private void SignInLabel_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    SignInTabItem.Background = new SolidColorBrush(Colors.White);
        //}

        //private void SignInLabel_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    SignInTabItem.Background = (System.Windows.Media.Brush)new BrushConverter().ConvertFrom("#41B1E1");
        //}

        //private void SignUpLabel_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    SignUpTabItem.Background = new SolidColorBrush(Colors.White);
        //}

        //private void SignUpLabel_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    SignUpTabItem.Background = (System.Windows.Media.Brush)new BrushConverter().ConvertFrom("#41B1E1");
        //}
        #endregion

        private void Flyout_ContextMenuClosing(object sender, RoutedEventArgs e)
        {
            LoginButton.Visibility = System.Windows.Visibility.Visible;
        }
    }
}