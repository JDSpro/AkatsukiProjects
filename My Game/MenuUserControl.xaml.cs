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

namespace My_Game
{
    /// <summary>
    /// Логика взаимодействия для MenuUserControl.xaml
    /// </summary>
    public partial class MenuUserControl : UserControl
    {
        public MenuUserControl()
        {
            InitializeComponent();

            labelExit.MouseDown += LabelExit_MouseDown;
            labelExit.MouseLeave += LabelExit_MouseLeave;
            labelExit.MouseEnter += LabelExit_MouseEnter;

            labelNewGame.MouseDown += LabelNewGame_MouseDown;
            labelNewGame.MouseLeave += LabelNewGame_MouseLeave;
            labelNewGame.MouseEnter += LabelNewGame_MouseEnter;
        }
        
        private void LabelNewGame_MouseEnter(object sender, MouseEventArgs e)
        {
            labelNewGame.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LabelNewGame_MouseLeave(object sender, MouseEventArgs e)
        {
            labelNewGame.Foreground = new SolidColorBrush(Colors.White);
        }
        
        private void LabelExit_MouseEnter(object sender, MouseEventArgs e)
        {
            labelExit.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void LabelExit_MouseLeave(object sender, MouseEventArgs e)
        {
            labelExit.Foreground = new SolidColorBrush(Colors.White);
        }

        private void LabelNewGame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserControlMenu.Visibility = Visibility.Hidden;
            Window mainWindow = Window.GetWindow(UserControlMenu);
            Grid gridOnMainWindow = mainWindow.Content as Grid;
            var children = gridOnMainWindow.Children;
            UserControl1 user = children[0] as UserControl1;
            user.Visibility = Visibility.Visible;
        }

        private void LabelExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window mainWindow = Window.GetWindow(UserControlMenu);
            mainWindow.Close();
        }
    }
}
