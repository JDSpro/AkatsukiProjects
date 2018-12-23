using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    public class Score
    {
        public int Id { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Balanse { get; set; }
        public float WinningPercentage { get; set; }
    }
}
