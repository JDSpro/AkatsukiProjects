using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }
}