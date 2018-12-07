using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    public static class Utilities
    {

        //РЕГИСТРАЦИЯ
        public static int Registration(string login, string password)
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
                    return JmixAcc.Id;
                }


                catch (DbUpdateException ex)
                {
                    //WebId = Guid.Empty;
                    return -1;
                }
            }
          
        }
            //using (MyContext db = new MyContext())
            //{
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


        //ВХОД
        public static int Enter(string login, string password)
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
                    return student.Id;
            }
            
            //если нет такого пользователя
            return -1;

            //если неверный пароль
//            return -2;


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
                return true;

            return false;
        }

        //Добавление и Сохранение дополнительных данных
        public static bool SaveAdditionalInfo(int id, byte[] imagePath, string name = "", string surname = "", string patronymic = "", string email = "")
        {

            MyContext context = new MyContext();

            IEnumerable<Account> acc = context.Accounts
                // Загрузить всех пользователей с Логином "login"
                .Where(c => c.Id == id)
                .AsEnumerable()
                // Поменять пароль
                .Select(c =>
                {
                    c.Personal.Name = name;
                    c.Personal.Surname = surname;
                    c.Personal.Patronymic = patronymic;
                    c.Personal.Email = email;
                    if (imagePath.Length>0)
                        c.Personal.Photo = imagePath;
                    
                    return c;
                });
            foreach (Account customer in acc)
                // Указать, что запись изменилась
                context.Entry(customer).State = EntityState.Modified;

            context.SaveChanges();

            //
            return false;
        }

        //получить картинку
        public static byte[] GetImage(int id)
        {
            //memorystreams-преобразовать из байтов в картинку
            MyContext context = new MyContext();

            var acc = context.Accounts
                // Загрузить всех пользователей с Логином "login"
                .Where(c => c.Id == id).First();

            return acc.Personal.Photo;
        }
        
        //полчучить логин
        public static string GetLogin(int id)
        {
            MyContext context = new MyContext();
            Account account = context.Accounts.Find(id);
            if (account != null)
                return account.Login;
            else
                return "";
        }

    }
}