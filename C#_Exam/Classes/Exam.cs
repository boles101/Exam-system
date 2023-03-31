using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__Exam.Classes
{
    public abstract class Exam 
    {
        public int Time{ get; set; }
        public static int NoQuestions { get; set; }
        Subject AssociatedSubject { get; set; }

        public Exam(int time , int noQ, Subject associatedSubject)
        {
            Time = time;
            NoQuestions = noQ;
            AssociatedSubject = associatedSubject;

        }
        public abstract void ShowExam();
    }
}
