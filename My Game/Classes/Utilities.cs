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
        public static void Seed()
        {
            using (MyContext db = new MyContext())
            {
                try
                {
                    // создаю аккаунт
                    Account JmixAcc = new Account
                    {
                        Login = "Игрок",
                        //128-битный алгоритм хеширования md5
                        Password = MD5Hash.GetMd5Hash("qwerty"),
                        Personal = new Personal_Data_Acc
                        {
                            DateOfBirth = new DateTime(2000, 08, 20),
                            Email = "email@gmail.com",
                            Name = "Пользователь1",
                            Patronymic = "Игоревич",
                            Surname = "Фамилиевич",
                            Photo = ImageToByte(@"C:\Users\student\Desktop\Luigi_5.png"),
                        }
                    };
                    // добавляю в бд
                    db.Accounts.Add(JmixAcc);
                    // db.Entry(JmixAcc).State = EntityState.Added;
                    db.SaveChanges();
                }

                catch (DbUpdateException ex)
                {
                    //WebId = Guid.Empty;
                    return;
                }

            }
        }

        //РЕГИСТРАЦИЯ
        public static Account Registration(string login, string password)
        {
            using (MyContext db = new MyContext())
            {
                try
                {
                    // создаю аккаунт
                    Account JmixAcc = new Account
                    {
                        Login = login,
                        //128-битный алгоритм хеширования md5
                        Password = MD5Hash.GetMd5Hash(password),
                        Personal = new Personal_Data_Acc { }
                    };
                    // добавляю в бд
                    db.Accounts.Add(JmixAcc);
                    // db.Entry(JmixAcc).State = EntityState.Added;
                    db.SaveChanges();
                    return JmixAcc;
                }

                catch (DbUpdateException ex)
                {
                    //WebId = Guid.Empty;
                    return null;
                }
            }
        }

        //ВХОД
        public static Account Enter(string login, string password)
        {
            using (var ctx = new MyContext())
            {
                //Выборка из базы данных, пользователя с логином, принимаемым в функции
                var student = (from s in ctx.Accounts
                               where s.Login == login
                               select s).FirstOrDefault<Account>();

                if (student == null)
                    //пароль совпал
                    return null;
                return student;
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
                // Указать, что запись изменилась
                context.Entry(customer).State = EntityState.Modified;

            context.SaveChanges();

            if (OldPass == MD5Hash.GetMd5Hash(newPass))
                return false;

            return true;
        }

        //Добавление и Сохранение дополнительных данных
        public static bool SaveAdditionalInfo(int id, string path, string name = "", string surname = "", string patronymic = "", string email = "")
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
                    c.Personal.Photo = ImageToByte(path);
                    return c;
                });
            foreach (Account customer in acc)
                // Указать, что запись изменилась
                context.Entry(customer).State = EntityState.Modified;

            context.SaveChanges();

            //
            return true;
        }

        public static byte[] ImageToByte(string path)
        {
            byte[] data;
            using (FileStream fs = new FileStream(new Uri(path).LocalPath, FileMode.Open, FileAccess.Read))
            {
                data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
            }

            return data;
        }

        public static BitmapImage ByteToImage(byte[] data)
        {
            MemoryStream memorystream = new MemoryStream();
            memorystream.Write(data, 0, (int)data.Length);

            BitmapImage imgsource = new BitmapImage();
            imgsource.BeginInit();
            imgsource.StreamSource = memorystream;
            imgsource.EndInit();

            return imgsource;
        }

        //public static Question GetRandQuestion(string login, string password)
        //{
        //    using (var ctx = new MyContext())
        //    {
        //        //Выборка из базы данных, пользователя с логином, принимаемым в функции
        //        var quest = (from s in ctx.Accounts
        //                     where s.Login == login
        //                     select s).FirstOrDefault<Account>();


        //        return quest;
        //    }

        //    return null;
        //}

        public static bool IsTrue()
        {

            return false;
        }
    }
}