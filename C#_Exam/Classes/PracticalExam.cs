using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Exam.Classes
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberofquestions, Subject subject) : base(time, numberofquestions, subject)
        {

        }

        public override void ShowExam()
        {
            Console.Clear();
            Stopwatch stopwatch = Stopwatch.StartNew();

            Console.WriteLine("Practical Exam:");

            foreach (Question question in Subject.question)
            {
                DisplayQuestion(question);
                int studentAnswerIndex = GetStudentAnswer(question);
            }

            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;
            Console.Clear();
            Console.WriteLine($"Elapsed time: {elapsed}");
            DisplayQuestionsWithCorrectAnswers(Subject.question);
        }

        private void DisplayQuestion(Question question)
        {
            Console.WriteLine($"{question.Header} {question.Body} ");
            DisplayAnswerOptions(question.Answers);
        }

        private void DisplayAnswerOptions(Answer[] answers)
        {
            foreach (Answer answer in answers)
            {
                Console.WriteLine($"{answer.AnswerId}) {answer.AnswerText}");
            }
        }

        private int GetStudentAnswer(Question question)
        {
            int studentAnswerIndex;
            do
            {
                Console.Write("Your answer: ");
            }
            while (!int.TryParse(Console.ReadLine(), out studentAnswerIndex) || studentAnswerIndex == 0 || studentAnswerIndex > question.Answers.Length);

            return studentAnswerIndex;
        }

        private void DisplayQuestionsWithCorrectAnswers(Question[] questions)
        {
            foreach (Question question in questions)
            {
                Console.WriteLine($"{question.Header} {question.Body} : The correct answer is: {question.Answers[question.RightAnswerIndex - 1].AnswerText}");
            }
        }
    }
}
