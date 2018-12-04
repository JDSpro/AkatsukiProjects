using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }

        public List<Personal_Data_Acc> Personal { get; set; }
    }
}