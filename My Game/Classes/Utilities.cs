using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    public static class Utilities
    {

        public static void Registration(string login, string password, string path)
        {
            using (MyContext db = new MyContext())
            {
                // создаем два объекта User
                Account JmixAcc = new Account
                {
                    Login = login,
                    //128-битный алгоритм хеширования md5
                    Password = MD5Hash.GetMd5Hash(password),
                    Photo = File.ReadAllBytes(path)
                    //Personal = new List<Personal_Data_Acc>
                    //{
                    //    new Personal_Data_Acc
                    //    {

                    //         Surname="Жмышенко",
                    //         Name="Валерий",
                    //         Patronymic="Альбертович",
                    //         // год - месяц - день - час - минута - секунда
                    //         DateOfBirth=new DateTime(1960, 08, 14, 12, 00, 00)
                    //    }
                    //}
                };
                // добавляю его в бд
                db.Entry(JmixAcc).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public static bool Enter(string login, string password)
        {
            if (true)
            {

                MyContext context = new MyContext();

                // Используем LINQ-запрос для извлечения первого заказчика
                var name = context.Accounts
                                  .Select(c => c.Login)
                                  .FirstOrDefault();
                return true;
            }
            return false;
        }

    }
}