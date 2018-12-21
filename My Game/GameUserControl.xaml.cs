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

        public MainWindow MainWindow { get; set; }

        //public ProgressUserControl Progress { get; set; }

        public UserControl1()
        {
            InitializeComponent();
            
            buttonAnswer1.Click += ButtonAnswer1_Click;
            buttonAnswer2.Click += ButtonAnswer2_Click;
            buttonAnswer3.Click += ButtonAnswer3_Click;
            buttonAnswer4.Click += ButtonAnswer4_Click;
        }

        private void ButtonAnswer1_Click(object sender, RoutedEventArgs e)
        {
            if(question.Answers[0].IsCorrect == true)
            {
                MainWindow.NextQuestion();
            }
            else
            {
                MainWindow.Lose();
            }
        }
        
        private void ButtonAnswer2_Click(object sender, RoutedEventArgs e)
        {
            if (question.Answers[1].IsCorrect == true)
            {
                MainWindow.NextQuestion();
            }
            else
            {
                MainWindow.Lose();
            }
        }

        private void ButtonAnswer3_Click(object sender, RoutedEventArgs e)
        {
            if (question.Answers[2].IsCorrect == true)
            {
                MainWindow.NextQuestion();
            }
            else
            {
                MainWindow.Lose();
            }
        }

        private void ButtonAnswer4_Click(object sender, RoutedEventArgs e)
        {
            if (question.Answers[3].IsCorrect == true)
            {
                MainWindow.NextQuestion();
            }
            else
            {
                MainWindow.Lose();
            }
        }

        public bool SetQuestion(Question qst)
        {
            if(qst == null)
            {
                return false;
            }
            question = qst;

            textBlockQuestion.Text = qst.Text;

            buttonAnswer1.Content = qst.Answers[0].Text;
            buttonAnswer2.Content = qst.Answers[1].Text;
            buttonAnswer3.Content = qst.Answers[2].Text;
            buttonAnswer4.Content = qst.Answers[3].Text;

            return true;
        }
    }
}
