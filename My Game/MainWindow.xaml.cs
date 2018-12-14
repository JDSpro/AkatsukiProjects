using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace My_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Account user;

        public MainWindow()
        {
            InitializeComponent();
            
            var d =Utilities.GetQuestion();
            ;
            SignInButton.Click += SignInButton_Click;
            SignUpButton.Click += SignUpButton_Click;

            TabCotrol.SelectionChanged += FlayoutTabCotrol_SelectionChanged;

            FlyoutSignInUp.IsOpenChanged += FlayoutSignInUp_IsOpenChanged;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsEmptyFields(SignInTextBox, SignInPasswordBox) == false)
            {
                user = Utilities.Enter(SignInTextBox.Text, SignInPasswordBox.Password);

                if (user != null)
                {
                    SetAccInfoFlyout();
                    LabelSignInError.Visibility = Visibility.Hidden;
                }
                else
                {
                    LabelSignInError.Content = "Неверный логин или пароль!";
                    LabelSignInError.Visibility = Visibility.Visible;
                }
            }
            else
            {
                LabelSignInError.Content = "Заполните все поля!";
                LabelSignInError.Visibility = Visibility.Visible;
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsEmptyFields(SignUpTextBox, SignUpPasswordBox) == false)
            {
                user = Utilities.Registration(SignUpTextBox.Text, SignUpPasswordBox.Password);

                if (user == null)
                {
                    LabelSignUpError.Content = "Логин уже используется.";
                    LabelSignUpError.Visibility = Visibility.Visible;
                }
                else
                {
                    SetAccInfoFlyout();
                    LabelSignUpError.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                LabelSignUpError.Content = "Заполните все поля!";
                LabelSignUpError.Visibility = Visibility.Visible;
            }
        }

        private void accountPicture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image accPicture = (Image)sender;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    accPicture.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                }
                catch (System.NotSupportedException)
                {
                    MessageBox.Show("Невернный формат изображения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void FlayoutTabCotrol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabCotrol.SelectedIndex == 0)
            {
                SignInTabItem.Background = new SolidColorBrush(Colors.White);
                SignUpTabItem.Background = (System.Windows.Media.Brush)new BrushConverter().ConvertFrom("#41B1E1");
                FlyoutSignInUp.Header = "Вход";

            }
            else if (TabCotrol.SelectedIndex == 1)
            {
                SignUpTabItem.Background = new SolidColorBrush(Colors.White);
                SignInTabItem.Background = (System.Windows.Media.Brush)new BrushConverter().ConvertFrom("#41B1E1");
                FlyoutSignInUp.Header = "Регистрация";
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                FlyoutSignInUp.IsOpen = true;
            }
            else
            {
                FlyoutSignInUp.Visibility = Visibility.Hidden;
                var flyout = Flyouts.Items[1] as Flyout;
                flyout.IsOpen = true;
            }

            //DialogManager.ShowLoginAsync(this, "", "");
        }

        private void FlayoutSignInUp_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            if (loginButton.IsVisible == true)
            {
                loginButton.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (loginButton.IsVisible == false)
            {
                loginButton.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void SetAccInfoFlyout()
        {
            FlyoutSignInUp.IsOpen = false;

            //Task.Run(new Action(() =>
            //{
            //    //Thread.Sleep(500);
            //    Dispatcher.Invoke(new Action(() =>
            //    {



            //if (user?.Personal?.Photo != null)
            //{
            BitmapImage userImage = Utilities.ByteToImage(user.Personal.Photo);
            accountPicture.Source = userImage;
            textBoxName.Text = user.Personal.Name;
            textBoxSurname.Text = user.Personal.Surname;
            textBoxPatronymic.Text = user.Personal.Patronymic;
            textBoxEmail.Text = user.Personal.Email;
            //}
            //else
            //{
            //    FileInfo fi = new FileInfo("../../Images/NoImage.png");
            //    accountPicture.Source = new BitmapImage(new Uri(fi.FullName));
            //}

            SetUserLogin(flyoutAccountInfoHeaderTextBlock);

            SetUserLogin(textBlockOnLabelOnButton);

            EllipseInLoginButton.Fill = new ImageBrush(userImage);
            
            flyoutAccountInfo.IsOpen = true;
            //    }));
            //}));
        }

        void SetUserLogin(TextBlock textBlockToSet)
        {
            if (user.Login.Length > 12)
            {
                string smallLogin = user.Login.Substring(0, 10);
                smallLogin += "...";
                textBlockToSet.Text = smallLogin;
                textBlockToSet.ToolTip = user.Login;
            }
            else
            {
                textBlockToSet.Text = user.Login;
            }
        }

        bool IsEmptyFields(TextBox login, PasswordBox password)
        {
            if (login.Text == "" || password.Password == "")
                return true;
            else
                return false;
        }

        private void flyoutAccountInfo_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (loginButton.IsVisible == true)
            {
                loginButton.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (loginButton.IsVisible == false)
            {
                loginButton.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void buttonSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Utilities.SaveAdditionalInfo(user.Id, accountPicture.Source.ToString(), textBoxName.Text, textBoxSurname.Text, textBoxPatronymic.Text, textBoxEmail.Text);
            EllipseInLoginButton.Fill = new ImageBrush(accountPicture.Source);
        }

        private void MetroWindow_StateChanged(object sender, EventArgs e)
        {
            //    if(WindowState == WindowState.Normal)
            //    {
            //        FlayoutSignInUp.Width = 205;
            //    }
            //    else if(WindowState == WindowState.Maximized)
            //    {
            //        FlayoutSignInUp.Width = 350;
            //        FlayoutSignInUp.Height = 450;
            //    }
        }
    }
}