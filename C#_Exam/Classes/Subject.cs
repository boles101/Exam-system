using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Exam.Classes
{
    public class Subject
    {
        public  int SubjectID { get; set; }
        public string? SubjectName { get; set; } 
        public Exam? SubjectExam { get; set; }

        public static Question[]? question;

        public void CreateExam()
        {
            question = new Question[Exam.NoQuestions];

            for (int i = 0; i < Exam.NoQuestions; i++)
            {
                Console.Clear();

                if (SubjectExam is PracticalExam)
                {
                    question[i] = CreateMCQ(i);
                }
                else if (SubjectExam is FinalExam)
                {
                    Console.Clear();

                    int questionType;

                    do
                    {
                        Console.Write($"Please choose the type of question number ({i + 1}): 1 for true/false, 2 for MCQ: ");
                    }
                    while (!int.TryParse(Console.ReadLine(), out questionType) || (questionType != 1 && questionType != 2));

                    if (questionType == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("True/False Question");
                        question[i] = CreateT_OR_F(i);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("MCQ Question");
                        question[i] = CreateMCQ(i);
                    }
                }
            }

            Console.Clear();
        }
        // Create MCQ 
        private Question CreateMCQ(int questionNumber)
        {
            var question = new Question

            {
                Header = $"Question {questionNumber + 1}:- ",
                Body = ReadLine($"Please enter Question #{questionNumber + 1}: ")
            };

            var mcq = new MCQ
            {
                answers = new Answer[4]
            };

            WriteLine("The choices of the question: ");
            for (int j = 0; j < 4; j++)
            {
                mcq.answers[j] = new Answer
                {
                    AnswerId = j + 1,
                    AnswerText = ReadLine($"Please enter choice {j + 1}: ")
                };
            }

            question.Answers = mcq.answers;

            question.RightAnswerIndex = ReadInt("Please specify the correct choice of the question: ", x => x > 0 && x <= 4);

            question.Mark = ReadInt("Please enter the marks of the question: ", x => x > 0);

            return question;
        }

        // True OR False Q
        private Question CreateT_OR_F(int questionNumber)
        {
            var question = new Question
            {
                Header = $"Question {questionNumber + 1}",
                Body = ReadLine($"Please enter Question #{questionNumber + 1}: ")
            };

            int rightAnswereIndex;
            do
            {
                Console.WriteLine("Please specify the correct choice of the question: \n1- True\n2-False\n ");
            }
            while (!int.TryParse(Console.ReadLine(), out rightAnswereIndex) || rightAnswereIndex > 2 || rightAnswereIndex == 0);

            question.RightAnswerIndex= rightAnswereIndex;

            question.Mark = ReadInt("Please enter the marks of the question: ", x => x > 0);

            TrueFalseQ tfq = new TrueFalseQ();
            tfq.answers = GetTrueFalseAnswers();
            question.Answers = tfq.answers;

            return question;
        }

                                    //------------------ helping Methods -------------------// 




        private string ReadLine(string message) 
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        private int ReadInt(string message, Func<int, bool> validator)
        {
            int value;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out value) || !validator(value));

            return value;
        }

        private void WriteLine(string message) 
        {
            Console.WriteLine(message);
        }

        private Answer[] GetTrueFalseAnswers() // (true or false Display )
        {
            Answer[] options = new Answer[2];
            options[0] = new Answer() { AnswerId = 1, AnswerText = "True" };
            options[1] = new Answer() { AnswerId = 2, AnswerText = "False" };
            return options;
        }




    }
}
