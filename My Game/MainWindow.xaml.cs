using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //-+-+-+-+-+-+-+-+-+-+-+-+-+-+TEST-+-+-+-+-+-+-+-+-+-+-+-+-+-+
            //бд создаеться на locsl db 
            //название бд Millioner
            
            using (MyContext db = new MyContext())
            {
                //
                Account account = new Account
                {
                    Login = "Jmix",
                    Password = "Jmix228",
                    Personal = new List<Personal_Data_Acc>
                    {
                     new Personal_Data_Acc
                     {
                         Surname = "Жмышенко",
                         Name = "Валерий",
                         Patronymic = "Альбертович",
                         DateOfBirth = new DateTime(1999, 6, 1),
                         Photo = File.ReadAllBytes("C:\\Users\\student\\Desktop\\rabota\\AkatsukiProjects\\My Game\\Uses.jpg" )
                     }
                }
                };

                Question question = new Question
                {
                    IssuePrice = 100,
                    Text = "сколько букв в русском алфавите?",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                           Text="33",
                           IsCorrect=true
                        },
                        new Answer{ Text="33", IsCorrect=false},
                        new Answer{ Text="34", IsCorrect=false},
                        new Answer{ Text="35", IsCorrect=false}

                    }
                };

                // добавляем их в бд
                db.Accounts.Add(account);
                db.SaveChanges();

                db.Questions.Add(question);
                db.SaveChanges();


                
            }
            //-+-+-+-+-+-+-+-+-+-+-+-+-+-+TEST-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var flyout = Flyouts.Items[0] as Flyout;
            flyout.IsOpen = true;

        }
    }
}
