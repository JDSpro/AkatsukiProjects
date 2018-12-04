using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game.Classes
{
    class GameHistory
    {
        public int Id { get; set; }
        public List<Account> Acc { get; set; }
        public int Points { get; set; }
        public DateTime DateOfPlay { get; set; }
    }
}