using C44_G00_Ex2.Questions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_Ex2.Exams
{
    internal class FinalExam:Exam
    {
        public FinalExam(int time, int numQuestions) : base(time, numQuestions) { }

        public override void ShowExam()
        {
            double total = 0;
            double userScore = 0;
            Stopwatch sw = Stopwatch.StartNew();
            List<int> userAnswers = new List<int>();

            Console.WriteLine("==== Final Exam Started ====");

            foreach (var question in Questions)
            {
                question.Show();
                Console.Write("Enter your answer ID: ");
                int userAns;
                while (!int.TryParse(Console.ReadLine(), out userAns))
                {
                    Console.Write("Invalid input. Enter a valid answer ID: ");
                }

                userAnswers.Add(userAns);

                if (question.CheckAnswer(userAns))
                {
                    userScore += question.Mark;
                }

                total += question.Mark;
            }

            sw.Stop();

            Console.WriteLine("\n==== Final Exam Finished ====");
            Console.WriteLine($"Your Score: {userScore}/{total}");
            Console.WriteLine($"Time Taken: {sw.Elapsed.Minutes}m {sw.Elapsed.Seconds}s");

            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"Q{i + 1}: Your Answer = {userAnswers[i]}, Correct Answer = {Questions[i].CorrectAnswerId}");
            }
        }
    }
}
