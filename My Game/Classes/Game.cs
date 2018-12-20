using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Game
{
    public class Game
    {
        List<Question> questionList;
        int currentStage = 0;

        public Game()
        {
            Utilities.Seed();
            questionList = Utilities.GetQuestions();
        }

        public Question GetQuestion()
        {
            if (currentStage >= questionList.Count)
                return null;
            return questionList[currentStage++];
        }
    }
}
