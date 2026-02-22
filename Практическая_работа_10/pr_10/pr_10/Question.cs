using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_10
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswerIndex { get; set; } 

        public Question(string text, string[] answers, int correctIndex)
        {
            QuestionText = text;
            Answers = answers;
            CorrectAnswerIndex = correctIndex;
        }

        public bool IsCorrect(int selectedIndex)
        {
            return selectedIndex == CorrectAnswerIndex;
        }
    }
}
