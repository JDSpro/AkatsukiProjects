using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace My_Game
{
    public static class Utilities
    {
        private static Random Rand = new Random();
        //Загрузка данных, для разработки(до релиза)
        public static void Seed()
        {
            using (MyContext context = new MyContext())
            {
                try
                {

                    #region 100 (6 вопросов)
                    Question quest1 = new Question
                    {
                        Text = "Сколько букв в русском алфавите?",
                        QuestionArnest = 1,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "32", IsCorrect = false},
                         new Answer{ Text = "33", IsCorrect = true},
                         new Answer{ Text = "34", IsCorrect = false},
                         new Answer{ Text = "35", IsCorrect = false}
                     }
                    };
                    Question quest2 = new Question
                    {
                        Text = "Операционная система от Microsoft называется...",
                        QuestionArnest = 1,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Двери", IsCorrect = false},
                         new Answer{ Text = "Форточки", IsCorrect = false},
                         new Answer{ Text = "Плитки", IsCorrect = false},
                         new Answer{ Text = "Окна", IsCorrect = true}
                     }
                    };
                    Question quest3 = new Question
                    {
                        Text = "Эмблему какого учреждения украшает змея обвивающая чашу?",
                        QuestionArnest = 1,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Зоопарк", IsCorrect = false},
                         new Answer{ Text = "Зоомагазин", IsCorrect = false},
                         new Answer{ Text = "Аптека", IsCorrect = true},
                         new Answer{ Text = "Дворец бракосочетаний", IsCorrect = false}
                     }
                    };
                    Question quest4 = new Question
                    {
                        Text = "Какого моря не существует?",
                        QuestionArnest = 1,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Красного моря", IsCorrect = false},
                         new Answer{ Text = "Белого моря", IsCorrect = false},
                         new Answer{ Text = "Черного моря", IsCorrect = false},
                         new Answer{ Text = "Сиреневого моря", IsCorrect = true}
                     }
                    };
                    Question quest5 = new Question
                    {
                        Text = "С какого расстояния назначают пенальти в футболе?",
                        QuestionArnest = 1,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "12 метров", IsCorrect = false},
                         new Answer{ Text = "11 метров", IsCorrect = true},
                         new Answer{ Text = "10 метров", IsCorrect = false},
                         new Answer{ Text = "9 метров", IsCorrect = false}
                     }
                    };
                    Question quest6 = new Question
                    {
                        Text = "Как в математике называется верное равенство двух отношений?",
                        QuestionArnest = 1,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Уравнение", IsCorrect = false},
                         new Answer{ Text = "Выражение", IsCorrect = false},
                         new Answer{ Text = "Пропорция", IsCorrect = true},
                         new Answer{ Text = "Тождество", IsCorrect = false}
                     }
                    };
                    #endregion
                    #region 2 (6 вопросов)
                    Question quest20 = new Question
                    {
                        Text = "В каком году был выпущен первый прототип портативного сотового телефона(Motorola DynaTAC)?",
                        QuestionArnest = 2,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "1964", IsCorrect = false},
                         new Answer{ Text = "1973", IsCorrect = true},
                         new Answer{ Text = "1982", IsCorrect = false},
                         new Answer{ Text = "1987", IsCorrect = false},
                     }
                    };
                    Question quest21 = new Question
                    {
                        Text = "В каком месяце в США традиционно начинаются президентские выборы?",
                        QuestionArnest = 2,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Август", IsCorrect = false},
                         new Answer{ Text = "Октябрь", IsCorrect = false},
                         new Answer{ Text = "Ноябрь", IsCorrect = true},
                         new Answer{ Text = "Февраль", IsCorrect = false}
                     }
                    };
                    Question quest22 = new Question
                    {
                        Text = "Какого персонажа не было среди Бременских музыкантов??",
                        QuestionArnest = 2,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Кот", IsCorrect = false},
                         new Answer{ Text = "Гусь", IsCorrect = true},
                         new Answer{ Text = "Собака", IsCorrect = false},
                         new Answer{ Text = "Осел", IsCorrect = false}
                     }
                    };
                    Question quest23 = new Question
                    {
                        Text = "В какое время года сутки короче?",
                        QuestionArnest = 2,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Летом", IsCorrect = false},
                         new Answer{ Text = "Зимой", IsCorrect = false},
                         new Answer{ Text = "Весной", IsCorrect = false},
                         new Answer{ Text = "Одинаковые", IsCorrect = true}
                     }
                    };
                    Question quest24 = new Question
                    {
                        Text = "Сколько государств участвовало во Второй мировой войне?",
                        QuestionArnest = 2,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "53", IsCorrect = false},
                         new Answer{ Text = "61", IsCorrect = true},
                         new Answer{ Text = "72", IsCorrect = false},
                         new Answer{ Text = "75", IsCorrect = false}
                     }
                    };
                    Question quest25 = new Question
                    {
                        Text = "Самая крупная рыба",
                        QuestionArnest = 2,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Белая акула", IsCorrect = false},
                         new Answer{ Text = "Китовая акула", IsCorrect = true},
                         new Answer{ Text = "Голубой кит", IsCorrect = false},
                         new Answer{ Text = "Синий кит", IsCorrect = false}
                     }
                    };
                    #endregion
                    #region 3
                    Question quest30 = new Question
                    {
                        Text = "Какая планета Солнечной системы самая большая? 3",
                        QuestionArnest = 3,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Земля", IsCorrect = false},
                         new Answer{ Text = "Юпитер", IsCorrect = true},
                         new Answer{ Text = "Венера", IsCorrect = false},
                         new Answer{ Text = "Плутон", IsCorrect = false}
                     }
                    };
                    #endregion
                    #region 4
                    Question quest40 = new Question
                    {
                        Text = "Какая планета? 4",
                        QuestionArnest = 4,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Земля", IsCorrect = false},
                         new Answer{ Text = "Юпитер", IsCorrect = true},
                         new Answer{ Text = "Венера", IsCorrect = false},
                         new Answer{ Text = "Плутон", IsCorrect = false}
                     }
                    };
                    #endregion
                    #region 5
                    Question quest50 = new Question
                    {
                        Text = "Какая? 5",
                        QuestionArnest = 5,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Земля", IsCorrect = false},
                         new Answer{ Text = "Юпитер", IsCorrect = true},
                         new Answer{ Text = "Венера", IsCorrect = false},
                         new Answer{ Text = "Плутон", IsCorrect = false}
                     }
                    };

                    #endregion
                    #region Add & Save
                    context.Questions.Add(quest1);
                    context.Questions.Add(quest2);
                    context.Questions.Add(quest3);
                    context.Questions.Add(quest4);
                    context.Questions.Add(quest5);
                    context.Questions.Add(quest6);
                    context.Questions.Add(quest20);
                    context.Questions.Add(quest21);
                    context.Questions.Add(quest22);
                    context.Questions.Add(quest23);
                    context.Questions.Add(quest24);
                    context.Questions.Add(quest25);
                    context.Questions.Add(quest30);
                    context.Questions.Add(quest40);
                    context.Questions.Add(quest50);
                    #endregion


                    /*
                    Question quest = new Question
                    {
                        Text = "",
                        IssuePrice = 200,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "", IsCorrect = false},
                         new Answer{ Text = "", IsCorrect = false},
                         new Answer{ Text = "", IsCorrect = false},
                         new Answer{ Text = "", IsCorrect = false}
                     }
                    };
                    context.Questions.Add(quest);
                    
                     */
                    context.SaveChanges();
                }

                catch (DbUpdateException ex)
                {
                    return;
                }
            }
        }


        public static void FirstConnection()
        {
            using (var context = new MyContext())
                context.Accounts.First();
        }

        //РЕГИСТРАЦИЯ
        public static Account Registration(string login, string password)
        {
            using (MyContext context = new MyContext())
            {
                try
                {
                    Account newAkk = new Account
                    {
                        Login = login,
                        Password = MD5Hash.GetMd5Hash(password),
                        Personal = new Personal_Data_Acc
                        {
                            Name = "",
                            Surname = "",
                            Patronymic = "",
                            Email = "",
                            Photo = ImageToByte(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Images\NoImage.png")
                        }
                    };
                    context.Accounts.Add(newAkk);
                    context.SaveChanges();
                    return newAkk;
                }

                catch (DbUpdateException ex)
                {
                    return null;
                }
            }
        }

        //ВХОД
        public static Account Enter(string login, string password)
        {
            using (var context = new MyContext())
            {
                Account akk = context.Accounts.Include(a => a.Personal).FirstOrDefault(a => a.Login == login);
                if ((akk != null) && (MD5Hash.VerifyMd5Hash(password, akk.Password)))
                    return akk;
                else
                    return null;
            }
        }

        //СМЕНА ПАРОЛЯ
        public static bool ChangePassword(int id, string newPass)
        {
            string OldPass = "";

            MyContext context = new MyContext();

            IEnumerable<Account> acc = context.Accounts
                // Загрузить всех пользователей по id
                .Where(c => c.Id == id)
                .AsEnumerable()
                // Поменять пароль
                .Select(c =>
                {
                    OldPass = c.Password;
                    c.Password = MD5Hash.GetMd5Hash(newPass);
                    return c;
                });
            foreach (Account customer in acc)
                context.Entry(customer).State = EntityState.Modified;

            context.SaveChanges();

            if (OldPass == MD5Hash.GetMd5Hash(newPass))
                return false;

            return true;
        }

        //Добавление и Сохранение дополнительных данных
        public static bool SaveAdditionalInfo(int id, string path = "", string name = "", string surname = "", string patronymic = "", string email = "")
        {
            MyContext context = new MyContext();
            IEnumerable<Account> acc = context.Accounts
                .Where(c => c.Id == id)
                .Include(a => a.Personal)
                .AsEnumerable()
                // Поменять пароль
                .Select(c =>
                {
                    c.Personal.Name = name;
                    c.Personal.Surname = surname;
                    c.Personal.Patronymic = patronymic;
                    c.Personal.Email = email;
                    if (path != ByteToImage(c.Personal.Photo).ToString())
                        c.Personal.Photo = ImageToByte(path);
                    return c;
                });
            foreach (Account customer in acc)
                context.Entry(customer).State = EntityState.Modified;

            context.SaveChanges();

            return true;
        }

        //Конвертер из картинки в байты
        public static byte[] ImageToByte(string path)
        {

            if (path != "")
            {
                byte[] data;

                using (FileStream fs = new FileStream(new Uri(path, UriKind.Absolute).LocalPath, FileMode.Open, FileAccess.Read))
                {
                    data = new byte[fs.Length];
                    fs.Read(data, 0, data.Length);
                }
                return data;
            }
            return null;
        }

        //Конвертер из байтов в картинки
        public static BitmapImage ByteToImage(byte[] data)
        {
            BitmapImage imgsource = new BitmapImage();
            imgsource.BeginInit();
            imgsource.StreamSource = new MemoryStream(data);
            imgsource.EndInit();

            return imgsource;
        }

        //Получить случайный вопрос цены price (внутри вопроса есть 4 ответа)
        public static IList<Question> GetQuestion()
        {
            List<Question> QstnList = new List<Question>();
            int i = 1;

            using (var context = new MyContext())
            {
                while (QstnList.Count < 5)
                {
                    var test = context.Questions.Where(c => c.QuestionArnest == i).ToList();
                    int n = Rand.Next(0, test.Count);

                    QstnList.Add(test[n]);
                    i++;
                }
                //question = context.Questions.Where(c => c.QuestionArnest == i);

                //foreach (var qst in question)
                //{
                //    if (max == 0)
                //        min = qst.Id;
                //    max = qst.Id;
                //}

                //lock (Rand)
                //    QstnList.Add(context.Questions.Find(Rand.Next(min, max + 1)));

                ////QstnList.Add(context.Questions.Find(Rand(min, max)));
                //max = 0;
                //min = 0;
                //i++;
            }
            return QstnList;
        }
    }
}