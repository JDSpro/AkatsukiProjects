using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    class Personal_Data_Acc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public byte[] Photo { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}