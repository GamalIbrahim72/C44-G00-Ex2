using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_Ex2.Questions
{
    internal class MCQQuestion:Question
    {
        public MCQQuestion(string body, double mark) : base(body, mark) { }

        public override void Show()
        {
            Console.WriteLine($"Q: {Body} (Mark: {Mark})");
            foreach (var ans in Answers)
            {
                Console.WriteLine($"{ans.Id}. {ans.Text}");
            }
        }
    }
}
