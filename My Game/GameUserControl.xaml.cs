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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        Question question;

        public UserControl1(Question qst)
        {
            InitializeComponent();

            question = qst;

            textBlockQuestion.Text = qst.Text;

            buttonAnswer1.Content = qst.Answers[0].Text;
            buttonAnswer2.Content = qst.Answers[1].Text;
            buttonAnswer3.Content = qst.Answers[2].Text;
            buttonAnswer4.Content = qst.Answers[3].Text;

            buttonAnswer1.Click += ButtonAnswer1_Click;
            buttonAnswer2.Click += ButtonAnswer2_Click;
            buttonAnswer3.Click += ButtonAnswer3_Click;
            buttonAnswer4.Click += ButtonAnswer4_Click;
        }

        private void ButtonAnswer1_Click(object sender, RoutedEventArgs e)
        {
            if(question.Answers[0].IsCorrect == true)
            {
                MainWindow yourParentWindow = (MainWindow)Window.GetWindow(questionAnswer);
                //yourParentWindow.
            }
            else
            {
                Window yourParentWindow = Window.GetWindow(questionAnswer);
                ;
            }
        }
        
        private void ButtonAnswer2_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonAnswer3_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonAnswer4_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
