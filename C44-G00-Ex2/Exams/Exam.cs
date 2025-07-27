using C44_G00_Ex2.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_Ex2.Exams
{
    internal abstract class Exam
    {
        public int Time { get; set; } 
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }

        public Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new List<Question>();
        }

        public abstract void ShowExam();
    }
}
