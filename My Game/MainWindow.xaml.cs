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

        Game game;

        public MainWindow()
        {
            InitializeComponent();

            SignInButton.Click += SignInButton_Click;
            SignUpButton.Click += SignUpButton_Click;

            TabCotrol.SelectionChanged += FlayoutTabCotrol_SelectionChanged;

            FlyoutSignInUp.IsOpenChanged += FlayoutSignInUp_IsOpenChanged;

            labelExit.MouseDown += LabelExit_MouseDown;
            labelExit.MouseLeave += LabelExit_MouseLeave;
            labelExit.MouseEnter += LabelExit_MouseEnter;

            labelNewGame.MouseDown += LabelNewGame_MouseDown;
            labelNewGame.MouseLeave += LabelNewGame_MouseLeave;
            labelNewGame.MouseEnter += LabelNewGame_MouseEnter;

            //WindowTitle = "Миллионер";
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsEmptyFields(SignInTextBox, SignInPasswordBox) == false)
            {
                user = Utilities.Enter(SignInTextBox.Text, SignInPasswordBox.Password);

                if (user == null)
                {
                    LabelSignInError.Content = "Неверный логин или пароль!";
                    LabelSignInError.Visibility = Visibility.Visible;
                }
                else
                {
                    SetAccInfoFlyout();
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
                    flyoutAccountInfo.IsOpen = true;
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
            
            BitmapImage userImage = Utilities.ByteToImage(user.Personal.Photo);
            accountPicture.Source = userImage;
            textBoxName.Text = user.Personal.Name;
            textBoxSurname.Text = user.Personal.Surname;
            textBoxPatronymic.Text = user.Personal.Patronymic;
            textBoxEmail.Text = user.Personal.Email;
            balance.Content = user.Score.Balanse;
            winCount.Content = user.Score.Wins;
            loseCount.Content = user.Score.Loses;

            stackPanelWinLose.ToolTip = "Процент побед: " + user.Score.WinningPercentage.ToString() + "%";

            SetUserLogin(flyoutAccountInfoHeaderTextBlock);

            SetUserLogin(textBlockOnLabelOnButton);

            EllipseInLoginButton.Fill = new ImageBrush(userImage);
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
            flyoutAccountInfo.IsOpen = false;
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

        private void mainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //mainWindow.
        }

        private void LabelNewGame_MouseEnter(object sender, MouseEventArgs e)
        {
            labelNewGame.Foreground = new SolidColorBrush(Colors.DarkGray);
        }

        private void LabelNewGame_MouseLeave(object sender, MouseEventArgs e)
        {
            labelNewGame.Foreground = new SolidColorBrush(Colors.White);
        }

        private void LabelExit_MouseEnter(object sender, MouseEventArgs e)
        {
            labelExit.Foreground = new SolidColorBrush(Colors.DarkGray);
        }

        private void LabelExit_MouseLeave(object sender, MouseEventArgs e)
        {
            labelExit.Foreground = new SolidColorBrush(Colors.White);
        }

        private void LabelExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void LabelNewGame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            labelExit.Visibility = Visibility.Hidden;
            labelNewGame.Visibility = Visibility.Hidden;

            progressBar.Visibility = Visibility.Visible;
            questionAnswer.Visibility = Visibility.Visible;

            FileInfo fi = new FileInfo("../../Images/EndBackground.jpg");
            backgroundImage.Source = new BitmapImage(new Uri(fi.FullName));

            //backgroundImage.Visibility = Visibility.Hidden;

            NewGame();
        }

        void NewGame()
        {
            game = new Game();

            questionAnswer.MainWindow = this;
            //questionAnswer.Progress = progressBar;

            NextQuestion();
        }

        public void NextQuestion()
        {
            if (questionAnswer.SetQuestion(game.GetQuestion()) == false && progressBar.CurrentStage >= 16)
            {
                Win();
                return;
            }
            else
            {
                progressBar.NextStage();
            }
        }

        public void Win()
        {
            if (user == null)
            {
                var res = MessageBox.Show("Вы выиграли! Желаете войти в аккаунт для обновления статистики?", "Выберите", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (res == MessageBoxResult.Yes)
                {
                    FlyoutSignInUp.IsOpen = true;
                }
            }
            else
            {
                MessageBox.Show("Вы выиграли! Статистика была обновлена.");
                Utilities.Win(user);
            }

            GameOver();
        }

        public void Lose()
        {
            if (user == null)
            {
                var res = MessageBox.Show("Вы Проиграли! Желаете войти в аккаунт для обновления статистики?", "Выберите", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (res == MessageBoxResult.Yes)
                {
                    FlyoutSignInUp.IsOpen = true;
                }
            }
            else
            {
                MessageBox.Show("Вы проиграли! Статистика была обновлена.");
                Utilities.Lose(user);
            }
           
            GameOver();
        }

        public void GameOver()
        {
            game = null;
            progressBar.EndGame();

            questionAnswer.Visibility = Visibility.Hidden;
            progressBar.Visibility = Visibility.Hidden;

            labelExit.Visibility = Visibility.Visible;
            labelNewGame.Visibility = Visibility.Visible;
        }
    }
}