using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_Ex2.Questions
{
    internal abstract class Question
    {
        public string Body { get; set; }
        public double Mark { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public int CorrectAnswerId { get; set; }

        public Question(string body, double mark)
        {
            Body = body;
            Mark = mark;
        }

        public abstract void Show();

        public bool CheckAnswer(int userAnswerId)
        {
            return userAnswerId == CorrectAnswerId;
        }
    }
}
