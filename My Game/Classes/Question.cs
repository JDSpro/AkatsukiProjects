using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int IssuePrice { get; set; }

        public List<Answer> Answers { get; set; }
    }
}