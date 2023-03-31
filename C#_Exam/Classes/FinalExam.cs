using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Exam.Classes
{
    public class FinalExam : Exam
    {
        public int NumberOfQuestions { get; }
        private int[] answerIndex;
        public FinalExam(int time,int numberOfQuestions, Subject subject) : base(time, numberOfQuestions,subject)
        {
            NumberOfQuestions = numberOfQuestions;
            answerIndex = new int[numberOfQuestions];
        }
        public override void ShowExam()
        {
            Console.Clear();
            Stopwatch stopwatch = Stopwatch.StartNew();

            Console.WriteLine("Final Exam:");
            Console.WriteLine($"Exam time in Minutes = {Time}");

            int totalMarks = 0;
            int studentTotalMarks = 0;
            int QIndex = 0;

            foreach (Question question in Subject.question)
            {
                totalMarks += question.Mark;

                Console.WriteLine($"{question.Header}: {question.Body} \t\t\tgrade: {question.Mark}");

                foreach (Answer answer in question.Answers)
                {
                    Console.WriteLine($"{answer.AnswerId}: {answer.AnswerText}");
                }

                bool IsValid = false;
                int AnswerIndex = 0;

                while (!IsValid)
                {
                    Console.Write("Answer: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out AnswerIndex) && AnswerIndex > 0 && AnswerIndex <= question.Answers.Length)
                    {
                        IsValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid answer.");
                    }
                }

                if (AnswerIndex == question.RightAnswerIndex)
                {
                    studentTotalMarks += question.Mark;
                }

                Console.Clear();
                QIndex++;
            }

            Console.WriteLine("Your Answers:\n");
            Console.WriteLine("------------------------------------------------");
            QIndex = 0;
            foreach (Question question in Subject.question)
            {
                Console.WriteLine($"{question.Header}): {question.Body}: {question.Answers[answerIndex[QIndex]].AnswerText}\n");
                QIndex++;
            }

            string elapsedTimeMessage = $"Elapsed time: {stopwatch.Elapsed}";

            if (Time * 60 < stopwatch.Elapsed.TotalSeconds)
            {
                Console.WriteLine($"Grade :  {studentTotalMarks}/{totalMarks}, el wa2t 5eles ya ahtal");
                Console.WriteLine(elapsedTimeMessage);
            }
            else
            {
                Console.WriteLine($"Grade :  {studentTotalMarks}/{totalMarks}");
                Console.WriteLine(elapsedTimeMessage);
            }
        }
    }
}
