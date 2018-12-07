using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    public class MyContext : DbContext
    {
        public MyContext() : base("Millioner")
        {
            Database.SetInitializer<MyContext>(new CreateDatabaseIfNotExists<MyContext>());
        }
        public DbSet<Account> Accounts{ get; set; }
        public DbSet<Personal_Data_Acc> Personal_Data_Accs{ get; set; }
        //public DbSet<GameHistory> Game_Histories{ get; set; }
        public DbSet<Question> Questions{ get; set; }
        public DbSet<Answer> Answers{ get; set; }
    }
}