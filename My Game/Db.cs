using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    public class Db
    {
        static Db instance;
        public MyContext Context { get; } = new MyContext();
        Db() { }
        public static Db GetInstance()
        {
            if (instance is null) instance = new Db();
            return instance;
        }
    }
}
