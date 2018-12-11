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
            
            SignInButton.Click += SignInButton_Click;
            SignUpButton.Click += SignUpButton_Click;

            TabCotrol.SelectionChanged += FlayoutTabCotrol_SelectionChanged;

            FlyoutSignInUp.IsOpenChanged += FlayoutSignInUp_IsOpenChanged;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (SignInTextBox.Text != "" && SignInPasswordBox.Password != "")
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
            if (SignUpTextBox.Text != "" && SignUpPasswordBox.Password != "")
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

        private void AccPicture_MouseDown(object sender, MouseButtonEventArgs e)
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

            Task.Run(new Action(() =>
            {
                //Thread.Sleep(500);
                Dispatcher.Invoke(new Action(() =>
                {
                    Flyout accInfoFlyout = new Flyout();

                    #region TextBoxName
                    TextBox TextBoxName = new TextBox();
                    TextBoxName.Width = 125;
                    TextBoxHelper.SetWatermark(TextBoxName, "Ваше имя");
                    TextBoxName.CaretBrush = new SolidColorBrush(Colors.Black);
                    TextBoxName.Background = new SolidColorBrush(Colors.White);
                    TextBoxName.Foreground = new SolidColorBrush(Colors.Black);
                    TextBoxName.Margin = new Thickness(0, 15, 0, 0);
                    #endregion

                    #region TextBoxSurname
                    TextBox TextBoxSurname = new TextBox();
                    TextBoxSurname.Width = 125;
                    TextBoxHelper.SetWatermark(TextBoxSurname, "Ваша фамилия");
                    TextBoxSurname.CaretBrush = new SolidColorBrush(Colors.Black);
                    TextBoxSurname.Background = new SolidColorBrush(Colors.White);
                    TextBoxSurname.Foreground = new SolidColorBrush(Colors.Black);
                    TextBoxSurname.Margin = new Thickness(0, 15, 0, 0);
                    #endregion

                    #region TextBoxPatronymic
                    TextBox TextBoxPatronymic = new TextBox();
                    TextBoxPatronymic.Width = 125;
                    TextBoxHelper.SetWatermark(TextBoxPatronymic, "Ваше отчество");
                    TextBoxPatronymic.CaretBrush = new SolidColorBrush(Colors.Black);
                    TextBoxPatronymic.Background = new SolidColorBrush(Colors.White);
                    TextBoxPatronymic.Foreground = new SolidColorBrush(Colors.Black);
                    TextBoxPatronymic.Margin = new Thickness(0, 15, 0, 0);
                    #endregion

                    #region TextBoxEmail
                    TextBox TextBoxEmail = new TextBox();
                    TextBoxEmail.Width = 125;
                    TextBoxHelper.SetWatermark(TextBoxEmail, "Email");
                    TextBoxEmail.CaretBrush = new SolidColorBrush(Colors.Black);
                    TextBoxEmail.Background = new SolidColorBrush(Colors.White);
                    TextBoxEmail.Foreground = new SolidColorBrush(Colors.Black);
                    TextBoxEmail.Margin = new Thickness(0, 15, 0, 0);
                    #endregion

                    #region AccPicture
                    Image AccPicture = new Image();

                    AccPicture.Width = 175;
                    AccPicture.Height = 150;
                    AccPicture.Margin = new Thickness(0, 0, 0, 0);
                    AccPicture.MouseDown += AccPicture_MouseDown;
                    
                    if (user.Personal != null)
                    {
                        var d = Utilities.ByteToImage(user.Personal.Photo);
                        AccPicture.Source = new BitmapImage(d.UriSource);
                    }
                    else
                    {
                        FileInfo fi = new FileInfo("../../Images/NoImage.png");
                        AccPicture.Source = new BitmapImage(new Uri(fi.FullName));
                    }
                    #endregion

                    #region ButtonSaveAccChanges
                    Button ButtonSaveAccChanges = new Button();
                    ButtonSaveAccChanges.Foreground = new SolidColorBrush(Colors.Black);
                    ButtonSaveAccChanges.Background = new SolidColorBrush(Colors.White);
                    ButtonSaveAccChanges.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDFD991"));
                    ButtonSaveAccChanges.Content = "Готово";
                    ButtonSaveAccChanges.Width = 75;
                    ButtonSaveAccChanges.Margin = new Thickness(0, 15, 0, 0);
                    ButtonSaveAccChanges.Click += ButtonSaveAccChanges_Click;
                    ButtonSaveAccChanges.Style = FindResource("ButtonStyle") as Style;
                    #endregion

                    StackPanel stack = new StackPanel();
                    stack.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#41B1E1"));

                    accInfoFlyout.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#41B1E1"));
                    accInfoFlyout.Content = stack;
                    accInfoFlyout.Width = 205;
                    accInfoFlyout.Position = Position.Left;
                    accInfoFlyout.IsVisibleChanged += AccInfoFlyout_IsVisibleChanged;
                    
                    TextBlock txtBlock = new TextBlock();
                    txtBlock.Text = user.Login;
                    txtBlock.FontSize = 20;
                    txtBlock.Foreground = new SolidColorBrush(Colors.Yellow);
                    txtBlock.TextWrapping = TextWrapping.Wrap;
                    txtBlock.FontStyle = FontStyles.Italic;

                    accInfoFlyout.Header = txtBlock;
                    
                    if (user.Login.Length > 12)
                    {
                        string smallLogin = user.Login.Substring(0, 11);
                        smallLogin += "...";
                        txtBlock.Text = smallLogin;
                        txtBlock.ToolTip = user.Login;
                    }
                    else
                    {
                        txtBlock.Text = user.Login;
                    }

                    LabelInLoginButton.Content = user.Login;

                    stack.Children.Add(AccPicture);
                    stack.Children.Add(TextBoxName);
                    stack.Children.Add(TextBoxSurname);
                    stack.Children.Add(TextBoxPatronymic);
                    stack.Children.Add(TextBoxEmail);
                    stack.Children.Add(ButtonSaveAccChanges);

                    Flyouts.Items.Add(accInfoFlyout);

                    accInfoFlyout.IsOpen = true;
                }));
            }));
        }

        private void AccInfoFlyout_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
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

        private void ButtonSaveAccChanges_Click(object sender, RoutedEventArgs e)
        {
            var flyout = Flyouts.Items[1] as Flyout;
            var stack = flyout.Content as StackPanel;
            var stackChildren = stack.Children;
            var image = stackChildren[0] as Image;

            Utilities.SaveAdditionalInfo(user.Id, image.Source.ToString());
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