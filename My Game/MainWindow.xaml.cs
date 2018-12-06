using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
                if(Utilities.Registration(SignInTextBox.Text, SignInPasswordBox.Password) == -1)
                {
                    LabelSignInError.Content = "Логин уже используется.";
                    LabelSignInError.Visibility = Visibility.Visible;
                }
                else
                {
                    SetNewFlyout();
                    LabelSignInError.Visibility = Visibility.Hidden;
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
                SetNewFlyout();
                LabelSignInError.Visibility = Visibility.Hidden;
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
            else if (LoginButton.IsVisible == false)
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
            
            //StackPanel panel = new StackPanel();

            //FlayoutSignInUp.Header = panel;

            //panel.Orientation = Orientation.Horizontal;

            //Image image = new Image();
            ////image.Source = 

            //Label label = new Label();
            ////label.Content =

            Task.Run(new Action(() =>
            {
                Thread.Sleep(500);
                Dispatcher.Invoke(new Action(() =>
                {
                    FlayoutSignInUp.Content = null;

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

                    AccPicture.Width = 100;
                    AccPicture.Height = 150;
                    AccPicture.Margin = new Thickness(0, 15, 0, 0);
                    AccPicture.MouseDown += AccPicture_MouseDown;
                    AccPicture.Source = new BitmapImage(new Uri(@"C:\Users\student\Desktop\My Game\AkatsukiProjects\My Game\Images\NoImage.png"));
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

                    //< Button Style = "{StaticResource ButtonStyle}" Name = "SignUpButton" BorderBrush = "#41b1e1" Foreground = "Black" Background = "White" Width = "75" Margin = "0, 15, 0, 0" Content = "Создать" ></ Button >

                    StackPanel stack = new StackPanel();

                    FlayoutSignInUp.Content = stack;

                    stack.Children.Add(TextBoxName);
                    stack.Children.Add(TextBoxSurname);
                    stack.Children.Add(TextBoxPatronymic);
                    stack.Children.Add(TextBoxEmail);
                    stack.Children.Add(AccPicture);
                    stack.Children.Add(ButtonSaveAccChanges);
                    
                    FlayoutSignInUp.IsOpen = true;
                }));
            }));


        }

        private void ButtonSaveAccChanges_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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