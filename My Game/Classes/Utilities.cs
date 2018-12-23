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
using System.Windows.Threading;

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

                    #region вопросы
                    Question quest1 = new Question
                    {
                        Text = "Сколько букв в русском алфавите?",
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
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Уравнение", IsCorrect = false},
                         new Answer{ Text = "Выражение", IsCorrect = false},
                         new Answer{ Text = "Пропорция", IsCorrect = true},
                         new Answer{ Text = "Тождество", IsCorrect = false}
                     }
                    };
                    Question quest7 = new Question
                    {
                        Text = "В каком году был выпущен первый прототип портативного сотового телефона(Motorola DynaTAC)?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "1964", IsCorrect = false},
                         new Answer{ Text = "1973", IsCorrect = true},
                         new Answer{ Text = "1982", IsCorrect = false},
                         new Answer{ Text = "1987", IsCorrect = false},
                     }
                    };
                    Question quest8 = new Question
                    {
                        Text = "В каком месяце в США традиционно начинаются президентские выборы?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Август", IsCorrect = false},
                         new Answer{ Text = "Октябрь", IsCorrect = false},
                         new Answer{ Text = "Ноябрь", IsCorrect = true},
                         new Answer{ Text = "Февраль", IsCorrect = false}
                     }
                    };
                    Question quest9 = new Question
                    {
                        Text = "Какого персонажа не было среди Бременских музыкантов??",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Кот", IsCorrect = false},
                         new Answer{ Text = "Гусь", IsCorrect = true},
                         new Answer{ Text = "Собака", IsCorrect = false},
                         new Answer{ Text = "Осел", IsCorrect = false}
                     }
                    };
                    Question quest10 = new Question
                    {
                        Text = "В какое время года сутки короче?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Летом", IsCorrect = false},
                         new Answer{ Text = "Зимой", IsCorrect = false},
                         new Answer{ Text = "Весной", IsCorrect = false},
                         new Answer{ Text = "Одинаковые", IsCorrect = true}
                     }
                    };
                    Question quest11 = new Question
                    {
                        Text = "Сколько государств участвовало во Второй мировой войне?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "53", IsCorrect = false},
                         new Answer{ Text = "61", IsCorrect = true},
                         new Answer{ Text = "72", IsCorrect = false},
                         new Answer{ Text = "75", IsCorrect = false}
                     }
                    };
                    Question quest12 = new Question
                    {
                        Text = "Самая крупная рыба?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Белая акула", IsCorrect = false},
                         new Answer{ Text = "Китовая акула", IsCorrect = true},
                         new Answer{ Text = "Голубой кит", IsCorrect = false},
                         new Answer{ Text = "Синий кит", IsCorrect = false}
                     }
                    };
                    Question quest13 = new Question
                    {
                        Text = "Какая планета Солнечной системы самая большая?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "Земля", IsCorrect = false},
                         new Answer{ Text = "Юпитер", IsCorrect = true},
                         new Answer{ Text = "Венера", IsCorrect = false},
                         new Answer{ Text = "Плутон", IsCorrect = false}
                     }
                    };
                    Question quest14 = new Question
                    {
                        Text = "Что говорит человек, когда замечает нечто необычное?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "бросилось в глаза", IsCorrect = true},
                         new Answer{ Text = "накапало в уши", IsCorrect = false},
                         new Answer{ Text = "попало в лоб", IsCorrect = false},
                         new Answer{ Text = "залетело в рот", IsCorrect = false}
                     }
                    };
                    Question quest15 = new Question
                    {
                        Text = "Какой элемент есть в конструкции башенного крана?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "стрела", IsCorrect = true},
                         new Answer{ Text = "копьё", IsCorrect = false},
                         new Answer{ Text = "дротик", IsCorrect = false},
                         new Answer{ Text = "бумеранг", IsCorrect = false}
                     }
                    };
                    Question quest16 = new Question
                    {
                        Text = "Какой клетки нет на шахматной доске?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "h8", IsCorrect = false},
                         new Answer{ Text = "b7", IsCorrect = false},
                         new Answer{ Text = "k6", IsCorrect = true},
                         new Answer{ Text = "g5", IsCorrect = false}
                     }
                    };
                    Question quest17 = new Question
                    {
                        Text = "Какой обряд перед свадьбой назывался рукобитьем?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "выяснение, кто сильнее", IsCorrect = false},
                         new Answer{ Text = "праздник друзей жениха", IsCorrect = false},
                         new Answer{ Text = "одевание невесты", IsCorrect = false},
                         new Answer{ Text = "скрепление договора", IsCorrect = true}
                     }
                    };
                    Question quest18 = new Question
                    {
                        Text = "Кто занимается незаконным копированием программного обеспечения?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "разбойник", IsCorrect = false},
                         new Answer{ Text = "налетчик", IsCorrect = false},
                         new Answer{ Text = "флибустьер", IsCorrect = false},
                         new Answer{ Text = "пират", IsCorrect = true}
                     }
                    };
                    Question quest19 = new Question
                    {
                        Text = "Что стало символом гостеприимства и радушия?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "чай-сахар", IsCorrect = false},
                         new Answer{ Text = "холодец-горчица", IsCorrect = false},
                         new Answer{ Text = "борщ-пампушки", IsCorrect = false},
                         new Answer{ Text = "хлеб-соль", IsCorrect = true}
                     }
                    };

                    Question quest20 = new Question
                    {
                        Text = "Что не предназначено для общественного питания?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "хостел", IsCorrect = true},
                         new Answer{ Text = "траттория", IsCorrect = false},
                         new Answer{ Text = "харчевня", IsCorrect = false},
                         new Answer{ Text = "бистро", IsCorrect = false}
                     }
                    };



                    Question quest21 = new Question
                    {
                        Text = "Для какого развлечения традиционно не требуется карандаш или ручка?",
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = "крестики-нолики", IsCorrect = false},
                         new Answer{ Text = "судоку", IsCorrect = false},
                         new Answer{ Text = "сканворд", IsCorrect = false},
                         new Answer{ Text = "оригами", IsCorrect = true}
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
                    context.Questions.Add(quest7);
                    context.Questions.Add(quest8);
                    context.Questions.Add(quest9);
                    context.Questions.Add(quest10);
                    context.Questions.Add(quest11);
                    context.Questions.Add(quest12);
                    context.Questions.Add(quest13);
                    context.Questions.Add(quest14);
                    context.Questions.Add(quest15);
                    context.Questions.Add(quest16);
                    context.Questions.Add(quest17);
                    context.Questions.Add(quest18);
                    context.Questions.Add(quest19);
                    context.Questions.Add(quest20);
                    context.Questions.Add(quest21);
                    #endregion
                    context.SaveChanges();
                }

                catch (DbUpdateException)
                {
                    return;
                }
            }
        }

        public static async void FirstConnectionAsync()
        {
            await Task.Run(() => FirstConnection());
        }

        private static void FirstConnection()
        {
            using (var context = new MyContext())
                context.Answers.First();
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
                        Score = new Score
                        {
                            Wins = 0,
                            Loses = 0,
                            Balanse = 0,
                        },
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

                catch (DbUpdateException)
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

        public static Score GetScore(Account account)
        {
            using (var context = new MyContext())
            {
                Account akk = context.Accounts.Include(a => a.Score).FirstOrDefault(a => a.Id == account.Id);
                return akk.Score;
            }
        }



        public static void Win(Account account)
        {
            using (var context = new MyContext())
            {
                var akk = GetScore(account);
                akk.Wins++;
                akk.Balanse = akk.Balanse + 1000000;
                akk.WinningPercentage = ((float)akk.Wins / (akk.Wins + akk.Loses) * 100);
                context.Entry(akk).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Lose(Account account)
        {
            using (var context = new MyContext())
            {
                var akk = GetScore(account);
                akk.Loses++;
                akk.WinningPercentage = ((float)akk.Wins / (akk.Wins + akk.Loses) * 100);
                context.Entry(akk).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        //Получить случайный список 15-сложностей вопросов (внутри вопроса есть 4 ответа)
        public static List<Question> GetQuestions()
        {
            int nomber = 0;
            using (var context = new MyContext())
            {
                List<Question> QstnList = new List<Question>();
                while (QstnList.Count < 15)
                {
                    var question = context.Questions.Include(t => t.Answers).ToList();
                    nomber = Rand.Next(0, question.Count);
                    if (QstnList.Find(item => item.Text == question[nomber].Text) == null)
                    {
                        QstnList.Add(question[nomber]);
                    }
                }
                return QstnList.ToList<Question>();
            }
        }

        public static void NewQuestion(string Qtext, int QArnest, string Answer1, string Answer2, string Answer3, string Answer4, int Correct)
        {
            using (var context = new MyContext())
            {
                if (Correct == 1)
                {
                    Question question = new Question
                    {
                        Text = Qtext,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = Answer1, IsCorrect = true},
                         new Answer{ Text = Answer2, IsCorrect = false},
                         new Answer{ Text = Answer3, IsCorrect = false},
                         new Answer{ Text = Answer4, IsCorrect = false}
                     }
                    };

                    context.Questions.Add(question);
                    context.SaveChanges();
                }
                else if (Correct == 2)
                {
                    Question question = new Question
                    {
                        Text = Qtext,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = Answer1, IsCorrect = false},
                         new Answer{ Text = Answer2, IsCorrect = true},
                         new Answer{ Text = Answer3, IsCorrect = false},
                         new Answer{ Text = Answer4, IsCorrect = false}
                     }
                    };
                    context.Questions.Add(question);
                    context.SaveChanges();
                }
                else if (Correct == 3)
                {
                    Question question = new Question
                    {
                        Text = Qtext,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = Answer1, IsCorrect = false},
                         new Answer{ Text = Answer2, IsCorrect = false},
                         new Answer{ Text = Answer3, IsCorrect = true},
                         new Answer{ Text = Answer4, IsCorrect = false}
                     }
                    };
                    context.Questions.Add(question);
                    context.SaveChanges();
                }
                else if (Correct == 4)
                {
                    Question question = new Question
                    {
                        Text = Qtext,
                        Answers = new List<Answer>
                     {
                         new Answer{ Text = Answer1, IsCorrect = false},
                         new Answer{ Text = Answer2, IsCorrect = false},
                         new Answer{ Text = Answer3, IsCorrect = false},
                         new Answer{ Text = Answer4, IsCorrect = true}
                     }
                    };
                    context.Questions.Add(question);
                    context.SaveChanges();
                }
            }
        }
    }
}