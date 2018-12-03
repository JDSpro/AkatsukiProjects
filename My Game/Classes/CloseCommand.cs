using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace My_Game
{
    public class CloseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        bool isOpen = false;
        MainWindow _wnd;
        public CloseCommand(MainWindow wnd)
        {
            _wnd = wnd;
        }

        public bool CanExecute(object parameter)
        {
            isOpen = !isOpen;
            Flyout f = parameter as Flyout;
            f.IsOpen = isOpen;
            return true;
        }

        public void Execute(object parameter)
        {
            _wnd.LoginButton.Visibility = Visibility.Visible;
        }
    }
}
