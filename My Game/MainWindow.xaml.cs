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
            
            SignUpPicture.MouseDown += SignUpPicture_MouseDown;

            SignInButton.Click += SignInButton_Click;
            SignUpButton.Click += SignUpButton_Click;

            TabCotrol.SelectionChanged += FlayoutTabCotrol_SelectionChanged;

            FlayoutSignInUp.IsOpenChanged += FlayoutSignInUp_IsOpenChanged;
        }
        
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (SignInTextBox.Text != "" && SignInPasswordBox.Password != "")
            {
                SetNewFlyout();
                LabelSignInError.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelSignInError.Content = "Заполните все поля!";
                LabelSignInError.Visibility = Visibility.Visible;
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (SignUpTextBox.Text != "" && SignUpPasswordBox.Password != "" && SignUpPicture.Source.ToString() != "")
            {
                SetNewFlyout();
                LabelSignInError.Visibility = Visibility.Hidden;
            }
            else
            {
                LabelSignUpError.Content = "Заполните все поля!";
                LabelSignUpError.Visibility = Visibility.Visible;
            }
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
        
        private void FlayoutTabCotrol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabCotrol.SelectedIndex == 0)
            {
                SignInTabItem.Background = new SolidColorBrush(Colors.White);
                SignUpTabItem.Background = (System.Windows.Media.Brush)new BrushConverter().ConvertFrom("#41B1E1");
                FlayoutSignInUp.Header = "Вход";

            }
            else if (TabCotrol.SelectedIndex == 1)
            {
                SignUpTabItem.Background = new SolidColorBrush(Colors.White);
                SignInTabItem.Background = (System.Windows.Media.Brush)new BrushConverter().ConvertFrom("#41B1E1");
                FlayoutSignInUp.Header = "Регистрация";
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var flyout = Flyouts.Items[0] as Flyout;
            flyout.IsOpen = true;
           
            //DialogManager.ShowLoginAsync(this, "", "");
        }

        private void FlayoutSignInUp_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            if (LoginButton.IsVisible == true)
            {
                LoginButton.Visibility = System.Windows.Visibility.Hidden;
            }
            else if(LoginButton.IsVisible == false)
            {
                LoginButton.Visibility = System.Windows.Visibility.Visible;
            }
        }

        //public string Name { get; set; }
        //public string Surname { get; set; }
        //public string Patronymic { get; set; }
        //public DateTime DateOfBirth { get; set; }

        private void SetNewFlyout()
        {
            FlayoutSignInUp.IsOpen = false;
            FlayoutSignInUp.Content = null;

            FlayoutSignInUp.Header = "JDS";

            TextBox TextBoxName = new TextBox();
            TextBoxName.Width = 150;
            TextBoxHelper.SetWatermark(TextBoxName, "Ваше имя");
            TextBoxName.CaretBrush = new SolidColorBrush(Colors.Black);
            TextBoxName.Background = new SolidColorBrush(Colors.White);
            TextBoxName.Foreground = new SolidColorBrush(Colors.Black);
            TextBoxName.Margin = new Thickness(0, 20, 0, 0);

            TextBox TextBoxSurname = new TextBox();
            TextBoxName.Width = 150;
            TextBoxHelper.SetWatermark(TextBoxName, "Ваше имя");
            TextBoxName.CaretBrush = new SolidColorBrush(Colors.Black);
            TextBoxName.Background = new SolidColorBrush(Colors.White);
            TextBoxName.Foreground = new SolidColorBrush(Colors.Black);
            TextBoxName.Margin = new Thickness(0, 20, 0, 0);

            TextBox TextBoxPatronymic = new TextBox();
            TextBoxName.Width = 150;
            TextBoxHelper.SetWatermark(TextBoxName, "Ваше имя");
            TextBoxName.CaretBrush = new SolidColorBrush(Colors.Black);
            TextBoxName.Background = new SolidColorBrush(Colors.White);
            TextBoxName.Foreground = new SolidColorBrush(Colors.Black);
            TextBoxName.Margin = new Thickness(0, 20, 0, 0);

            
        }
    }
}