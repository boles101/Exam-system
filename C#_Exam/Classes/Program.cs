using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace C__Exam.Classes
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Subject subject = new Subject { };
            int examtype = ReadInt("choose exam:-\n\t\t1-practical\t\t2-final.\n", x => x == 1 || x == 2);
            int time = ReadInt("time of exam : ", x => x > 0);
            int NoOfquestions = ReadInt("number of questions : ", x => x > 0);
            Exam exam;

            if (examtype == 1)
                exam = new PracticalExam(time, NoOfquestions, subject);
            else 
                exam = new FinalExam(time, NoOfquestions, subject);

            subject.SubjectExam = exam;
            subject.CreateExam();
            int confirmation = ReadInt("Press 1 : Start Exam\nPress 2 : Close", x => x == 1 || x == 2);
            if (confirmation == 1)
            {
                exam.ShowExam();
            }
            else
                Console.WriteLine("Some Another time Ya a5ooya");





        }

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }


        private static int ReadInt(string message, Func<int, bool> validator)
        {
            int value;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out value) || !validator(value));

            return value;
        }
    }
}