using System;
using System.Collections.Generic;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher engin = new Teacher(mediator)
            {
                Name = "Engin"
            };
            Student derin = new Student(mediator)
            {
                Name = "Derin"
            };
            Student salih = new Student(mediator)
            {
                Name = "Salih"
            };
            mediator.Teacher = engin;
            mediator.Students = new List<Student>
            {
                derin, salih
            };

            engin.SendNewImageUrl("slide1.jpg");
            engin.ReceiveQuestion("Is it true?", salih);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReceiveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.ReceiveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {

        }

        public string Name { get; set; }

        public void ReceiveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher received a question from {0}, {1}", student.Name, question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0}, {1}", student.Name, answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }

        public string Name { get; set; }

        public void ReceiveImage(string url)
        {
            Console.WriteLine("{1} received image : {0}", url, Name);
        }
        
        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine("Student received answer {0}", answer);
        }
    }
}
