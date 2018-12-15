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

        private Game()
        {
            questionList = Utilities.GetQuestions();
        }

        public Question GetQuestion()
        {
            return questionList[currentStage++];
        }

        public void GameOver()
        {
            currentStage = 0;
            questionList = null;
        }


    }
}
