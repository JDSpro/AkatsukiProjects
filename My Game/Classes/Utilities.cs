using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    public static class Utilities
    {

        //РЕГИСТРАЦИЯ
        public static void Registration(string login, string password, string path)
        {
            using (MyContext db = new MyContext())
            {
                // создаю аккаунт
                Account JmixAcc = new Account
                {
                    Login = login,
                    //128-битный алгоритм хеширования md5
                    Password = MD5Hash.GetMd5Hash(password),
                    //Photo = File.ReadAllBytes(path)
                };

                // добавляю в бд
                db.Entry(JmixAcc).State = EntityState.Added;
                db.SaveChanges();
            }


            //using (MyContext db = new MyContext())
            //{
            //    // создаем два объекта User
            //    Account JmixAcc = new Account
            //    {
            //        Login = login,
            //        //128-битный алгоритм хеширования md5
            //        Password = MD5Hash.GetMd5Hash(password),
            //        //Photo = File.ReadAllBytes(path)
            //        //Personal = new List<Personal_Data_Acc>
            //        //{
            //        //    new Personal_Data_Acc
            //        //    {

            //        //         Surname="Жмышенко",
            //        //         Name="Валерий",
            //        //         Patronymic="Альбертович",
            //        //         // год - месяц - день - час - минута - секунда
            //        //         DateOfBirth=new DateTime(1960, 08, 14, 12, 00, 00)
            //        //    }
            //        //}
            //    };
            //    // добавляю его в бд
            //    db.Entry(JmixAcc).State = System.Data.Entity.EntityState.Added;
            //    db.SaveChanges();
            //}
        }

        //ВХОД
        public static bool Enter(string login, string password)
        {
            if (true)
            {
                MyContext context = new MyContext();

                using (var ctx = new MyContext())
                {
                    //Выборка из базы данных, пользователя с логином, принимаемым в функции
                    var student = (from s in ctx.Accounts
                                   where s.Login == login
                                   select s).FirstOrDefault<Account>();

                    if (student.Password == MD5Hash.GetMd5Hash(password))
                        //если и пароль у этого пользвателя совпал то return true
                        return true;
                }
            }
            return false;
        }

        //СМЕНА ПАРОЛЯ
        public static bool ChangePassword(string login, string newPass)
        {
            if (true)
            {
                MyContext context = new MyContext();

                IEnumerable<Account> acc = context.Accounts
                    // Загрузить всех покупателей с фамилией "Иванов"
                    .Where(c => c.Login == login)
                    .AsEnumerable()
                    // Поменять им всем фамилию
                    .Select(c =>
                    {
                        c.Password = MD5Hash.GetMd5Hash(newPass);
                        return c;
                    });

                foreach (Account customer in acc)
                {
                    // Указать, что запись изменилась
                    context.Entry(customer).State = EntityState.Modified;
                }

                context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}