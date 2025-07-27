using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_Ex2.Questions
{
    internal class TFQuestion:Question
    {
        public TFQuestion(string body, double mark) : base(body, mark)
        {
            Answers.Add(new Answer(1, "True"));
            Answers.Add(new Answer(2, "False"));
        }

        public override void Show()
        {
            Console.WriteLine($"Q: {Body} (Mark: {Mark})");
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }
    }
}
