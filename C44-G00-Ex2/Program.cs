using C44_G00_Ex2;
using C44_G00_Ex2.Exams;
using C44_G00_Ex2.Questions;

internal class Program
{
    private static List<Question> questions;

    private static void Main(string[] args)
    {
        Console.WriteLine("Choose Exam Type: 1. Final Exam - 2. Practical Exam");
        int examTypeChoice = int.Parse(Console.ReadLine());

        int time;
        do
        {
            Console.WriteLine("Enter Exam Time (30 - 180 minutes): ");
            time = int.Parse(Console.ReadLine());
        } while (time < 30 || time > 180);

        Console.WriteLine("Enter Number of Questions: ");
        int questionCount = int.Parse(Console.ReadLine());

        Exam exam;
        if (examTypeChoice == 1)
            exam = new FinalExam(time, questionCount);
        else
            exam = new PracticalExam(time, questionCount);

        Console.Clear();

        for (int i = 0; i < questionCount; i++)
        {
            Console.WriteLine($"\nEnter data of Question {i + 1}:");

            int questionType;
            do
            {
                Console.WriteLine("Choose Question Type: 1. MCQ  2. True/False");
                bool valid = int.TryParse(Console.ReadLine(), out questionType);
                if (!valid || (questionType != 1 && questionType != 2))
                    Console.WriteLine("Invalid input! Please enter 1 for MCQ or 2 for True/False.");
            } while (questionType != 1 && questionType != 2);

            Console.Write("Enter Question Body: ");
            string body = Console.ReadLine();

            Console.Write("Enter Mark for this Question: ");
            double mark = double.Parse(Console.ReadLine());

            Question question;

            if (questionType == 1)
            {
                question = new MCQQuestion(body, mark);

                for (int j = 1; j <= 3; j++)
                {
                    Console.Write($"Enter Choice {j}: ");
                    string choiceText = Console.ReadLine();
                    question.Answers.Add(new Answer(j, choiceText));
                }

                int correctId;
                do
                {
                    Console.Write("Enter Correct Answer ID (1-3): ");
                    correctId = int.Parse(Console.ReadLine());
                    if (correctId < 1 || correctId > 3)
                        Console.WriteLine(" Please enter a number between 1 and 3.");
                } while (correctId < 1 || correctId > 3);

                question.CorrectAnswerId = correctId;
            }
            else
            {
                question = new TFQuestion(body, mark);

                int correctId;
                do
                {
                    Console.Write("Enter Correct Answer ID (1 for True, 2 for False): ");
                    correctId = int.Parse(Console.ReadLine());
                    if (correctId != 1 && correctId != 2)
                        Console.WriteLine(" Please enter 1 for True or 2 for False.");
                } while (correctId != 1 && correctId != 2);

                question.CorrectAnswerId = correctId;
            }

            exam.Questions.Add(question);
        }

        Console.WriteLine("\nDo you want to start the exam now? (yes/no): ");
        string start = Console.ReadLine().ToLower();

        if (start == "yes" || start == "y")
        {
            Console.Clear();
            exam.ShowExam();
        }
        else
        {
            Console.WriteLine("Exam cancelled.");
        }
    }
}
