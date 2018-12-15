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
using System.Windows.Shapes;

namespace My_Game
{
    /// <summary>
    /// Логика взаимодействия для Window_For_Fill_Questions.xaml
    /// </summary>
    public partial class Window_For_Fill_Questions : Window
    {
        public Window_For_Fill_Questions()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RB1.IsChecked==true)
                Utilities.NewQuestion(TBox_TextQuestion.Text, Convert.ToInt16(TBox_Complexityes.Text), TBox_Answer1.Text, TBox_Answer2.Text, TBox_Answer3.Text, TBox_Answer4.Text, 1);
            else if (RB2.IsChecked == true)
                Utilities.NewQuestion(TBox_TextQuestion.Text, Convert.ToInt16(TBox_Complexityes.Text), TBox_Answer1.Text, TBox_Answer2.Text, TBox_Answer3.Text, TBox_Answer4.Text, 2);
            else if (RB3.IsChecked == true)
                Utilities.NewQuestion(TBox_TextQuestion.Text, Convert.ToInt16(TBox_Complexityes.Text), TBox_Answer1.Text, TBox_Answer2.Text, TBox_Answer3.Text, TBox_Answer4.Text, 3);
            else
                Utilities.NewQuestion(TBox_TextQuestion.Text,Convert.ToInt16(TBox_Complexityes.Text), TBox_Answer1.Text, TBox_Answer2.Text, TBox_Answer3.Text, TBox_Answer4.Text, 4);

            TBox_TextQuestion.Text = "";
            TBox_Answer1.Text = "";
            TBox_Answer2.Text = "";
            TBox_Answer3.Text = "";
            TBox_Answer4.Text = "";

        }
    }
}
